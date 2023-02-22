using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InstitutoUrquiza.Context;
using InstitutoUrquiza.Models;

namespace InstitutoUrquiza.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly InstitutoUrquizaDBContext _context;

        public ProfesoresController(InstitutoUrquizaDBContext context)
        {
            _context = context;
        }

        // GET: Profesores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profesores.ToListAsync());
        }

        // GET: Profesores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // GET: Profesores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Dni,Email,Celular,FechaIngreso,esActivo")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                var existeProfeDni = from p in _context.Profesores
                                     where p.Dni == profesor.Dni
                                     select p;

                var existeProfeEmail = from p in _context.Profesores
                                       where p.Email == profesor.Email
                                       select p;


                if (!existeProfeDni.Any() && !existeProfeEmail.Any())

                {
                    _context.Add(profesor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    if (existeProfeDni.Any() && existeProfeEmail.Any())

                    {
                        ModelState.AddModelError("Dni", "Ya existe un profe con ese DNI. Por favor, revise los datos ingresados.");
                        ModelState.AddModelError("Email", "Ya existe un profe con ese e-mail. Por favor, revise los datos ingresados.");
                    }

                    else if (existeProfeDni.Any())
                    {
                        ModelState.AddModelError("Dni", "Ya existe un profe con ese DNI. Por favor, revise los datos ingresados.");
                    }
                    else if (existeProfeEmail.Any())
                    {
                        ModelState.AddModelError("Email", "Ya existe un profe con ese e-mail. Por favor, revise los datos ingresados.");
                    }


                    return View();
                }
            }
            return View(profesor);
        }

        // GET: Profesores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        // POST: Profesores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Dni,Email,Celular,FechaIngreso,esActivo")] Profesor profesor)
        {
            if (id != profesor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorExists(profesor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(profesor);
        }

        // GET: Profesores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            _context.Profesores.Remove(profesor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorExists(int id)
        {
            return _context.Profesores.Any(e => e.Id == id);
        }
    }
}
