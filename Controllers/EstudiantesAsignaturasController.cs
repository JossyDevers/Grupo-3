using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentService.Models;

namespace StudentService.Controllers
{
    public class EstudiantesAsignaturasController : Controller
    {
        private readonly StudentServiceContext _context;

        public EstudiantesAsignaturasController(StudentServiceContext context)
        {
            _context = context;
        }

        // GET: EstudiantesAsignaturas
        public async Task<IActionResult> Index()
        {
            var studentServiceContext = _context.EstudiantesAsignaturas.Include(e => e.IdAsignaturaNavigation).Include(e => e.IdEstudianteNavigation);
            return View(await studentServiceContext.ToListAsync());
        }

        // GET: EstudiantesAsignaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantesAsignaturas = await _context.EstudiantesAsignaturas
                .Include(e => e.IdAsignaturaNavigation)
                .Include(e => e.IdEstudianteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiantesAsignaturas == null)
            {
                return NotFound();
            }

            return View(estudiantesAsignaturas);
        }

        // GET: EstudiantesAsignaturas/Create
        public IActionResult Create()
        {
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "Id", "Nombre");
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "Id", "Apellido");
            return View();
        }

        // POST: EstudiantesAsignaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdAsignatura,IdEstudiante,FechaMatriculacion,FechaTermino,Calificacion")] EstudiantesAsignaturas estudiantesAsignaturas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiantesAsignaturas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "Id", "Nombre", estudiantesAsignaturas.IdAsignatura);
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "Id", "Apellido", estudiantesAsignaturas.IdEstudiante);
            return View(estudiantesAsignaturas);
        }

        // GET: EstudiantesAsignaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantesAsignaturas = await _context.EstudiantesAsignaturas.FindAsync(id);
            if (estudiantesAsignaturas == null)
            {
                return NotFound();
            }
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "Id", "Nombre", estudiantesAsignaturas.IdAsignatura);
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "Id", "Apellido", estudiantesAsignaturas.IdEstudiante);
            return View(estudiantesAsignaturas);
        }

        // POST: EstudiantesAsignaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAsignatura,IdEstudiante,FechaMatriculacion,FechaTermino,Calificacion")] EstudiantesAsignaturas estudiantesAsignaturas)
        {
            if (id != estudiantesAsignaturas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiantesAsignaturas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudiantesAsignaturasExists(estudiantesAsignaturas.Id))
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
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "Id", "Nombre", estudiantesAsignaturas.IdAsignatura);
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiantes, "Id", "Apellido", estudiantesAsignaturas.IdEstudiante);
            return View(estudiantesAsignaturas);
        }

        // GET: EstudiantesAsignaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantesAsignaturas = await _context.EstudiantesAsignaturas
                .Include(e => e.IdAsignaturaNavigation)
                .Include(e => e.IdEstudianteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiantesAsignaturas == null)
            {
                return NotFound();
            }

            return View(estudiantesAsignaturas);
        }

        // POST: EstudiantesAsignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiantesAsignaturas = await _context.EstudiantesAsignaturas.FindAsync(id);
            _context.EstudiantesAsignaturas.Remove(estudiantesAsignaturas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudiantesAsignaturasExists(int id)
        {
            return _context.EstudiantesAsignaturas.Any(e => e.Id == id);
        }
    }
}
