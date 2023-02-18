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
    public class ClasesController : Controller
    {
        private readonly InstitutoUrquizaDBContext _context;

        public ClasesController(InstitutoUrquizaDBContext context)
        {
            _context = context;
        }

        // GET: Clases
        public async Task<IActionResult> Index()
        {
            var institutoUrquizaDBContext = _context.Clases.Include(c => c.Estudiante).Include(c => c.Profesor);
            return View(await institutoUrquizaDBContext.ToListAsync());
        }

        // GET: Clases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clases
                .Include(c => c.Estudiante)
                .Include(c => c.Profesor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clase == null)
            {
                return NotFound();
            }

            return View(clase);
        }

        // GET: Clases/Create
        public IActionResult Create()
        {
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Apellido");
            ViewData["ProfesorId"] = new SelectList(_context.Profesores, "Id", "Apellido");
            return View();
        }

        // POST: Clases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Actividad,horario,ProfesorId,EstudianteId,Salon")] Clase clase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Apellido", clase.EstudianteId);
            ViewData["ProfesorId"] = new SelectList(_context.Profesores, "Id", "Apellido", clase.ProfesorId);
            return View(clase);
        }

        // GET: Clases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clases.FindAsync(id);
            if (clase == null)
            {
                return NotFound();
            }
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Apellido", clase.EstudianteId);
            ViewData["ProfesorId"] = new SelectList(_context.Profesores, "Id", "Apellido", clase.ProfesorId);
            return View(clase);
        }

        // POST: Clases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Actividad,horario,ProfesorId,EstudianteId,Salon")] Clase clase)
        {
            if (id != clase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaseExists(clase.Id))
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
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Apellido", clase.EstudianteId);
            ViewData["ProfesorId"] = new SelectList(_context.Profesores, "Id", "Apellido", clase.ProfesorId);
            return View(clase);
        }

        // GET: Clases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clase = await _context.Clases
                .Include(c => c.Estudiante)
                .Include(c => c.Profesor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clase == null)
            {
                return NotFound();
            }

            return View(clase);
        }

        // POST: Clases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clase = await _context.Clases.FindAsync(id);
            _context.Clases.Remove(clase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaseExists(int id)
        {
            return _context.Clases.Any(e => e.Id == id);
        }
    }
}
