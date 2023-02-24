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
    public class EstudiantesController : Controller
    {
        private readonly InstitutoUrquizaDBContext _context;

        public EstudiantesController(InstitutoUrquizaDBContext context)
        {
            _context = context;
        }

        // GET: Estudiantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudiantes.ToListAsync());
        }

        // GET: Estudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Dni,Edad,Email,Celular,FechaIngreso,Nivel,cuotaAlDia")] Estudiante estudiante)
        {

            if (ModelState.IsValid)
            {
                var existeAlumnoDni = from e in _context.Estudiantes
                                      where e.Dni == estudiante.Dni
                                      select e;

                var existeAlumnoEmail = from e in _context.Estudiantes
                                        where e.Email == estudiante.Email
                                        select e;

                if (!existeAlumnoDni.Any() && !existeAlumnoEmail.Any())
                {
                    _context.Add(estudiante);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    if (existeAlumnoDni.Any() && existeAlumnoEmail.Any())
                    {
                        ModelState.AddModelError("Dni", "Ya existe un alumno con ese DNI. Por favor, revise los datos ingresados.");
                        ModelState.AddModelError("Email", "Ya existe un alumno con ese e-mail. Por favor, revise los datos ingresados.");
                    }
                    else if (existeAlumnoDni.Any())
                    {
                        ModelState.AddModelError("Dni", "Ya existe un alumno con ese DNI. Por favor, revise los datos ingresados.");
                    }
                    else if (existeAlumnoEmail.Any())
                    {
                        ModelState.AddModelError("Email", "Ya existe un alumno con ese e-mail. Por favor, revise los datos ingresados.");
                    }


                    return View();
                }
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Dni,Edad,Email,Celular,FechaIngreso,Nivel,cuotaAlDia")] Estudiante estudiante)
        {
            if (id != estudiante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var existeAlumnoDni = from e in _context.Estudiantes
                                          where e.Dni == estudiante.Dni
                                          select e;

                    var existeAlumnoEmail = from e in _context.Estudiantes
                                            where e.Email == estudiante.Email
                                            select e;

                    if (!existeAlumnoDni.Any() && !existeAlumnoEmail.Any())
                    {
                        _context.Update(estudiante);
                        await _context.SaveChangesAsync();

                    }
                    else
                    {
                        if (existeAlumnoDni.Any() && existeAlumnoEmail.Any())
                        {
                            ModelState.AddModelError("Dni", "Ya existe un alumno con ese DNI. Por favor, revise los datos ingresados.");
                            ModelState.AddModelError("Email", "Ya existe un alumno con ese e-mail. Por favor, revise los datos ingresados.");
                        }
                        else if (existeAlumnoDni.Any())
                        {
                            ModelState.AddModelError("Dni", "Ya existe un alumno con ese DNI. Por favor, revise los datos ingresados.");
                        }
                        else if (existeAlumnoEmail.Any())
                        {
                            ModelState.AddModelError("Email", "Ya existe un alumno con ese e-mail. Por favor, revise los datos ingresados.");
                        }

                        return View();
                    }

                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.Id))
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
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiantes.Any(e => e.Id == id);
        }
    }
}
