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
    public class AsignaturaEquivalentesController : Controller
    {
        private readonly StudentServiceContext _context;

        public AsignaturaEquivalentesController(StudentServiceContext context)
        {
            _context = context;
        }

        // GET: AsignaturaEquivalentes
        public async Task<IActionResult> Index()
        {
            var studentServiceContext = _context.AsignaturaEquivalentes.Include(a => a.IdAsignaturaEquivalenteNavigation).Include(a => a.IdAsignaturaNavigation);
            return View(await studentServiceContext.ToListAsync());
        }

        // GET: AsignaturaEquivalentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturaEquivalentes = await _context.AsignaturaEquivalentes
                .Include(a => a.IdAsignaturaEquivalenteNavigation)
                .Include(a => a.IdAsignaturaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignaturaEquivalentes == null)
            {
                return NotFound();
            }

            return View(asignaturaEquivalentes);
        }

        // GET: AsignaturaEquivalentes/Create
        public IActionResult Create()
        {
            ViewData["IdAsignaturaEquivalente"] = new SelectList(_context.Asignaturas, "Id", "Curso");
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "Id", "Curso");
            return View();
        }

        // POST: AsignaturaEquivalentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdAsignatura,IdAsignaturaEquivalente")] AsignaturaEquivalentes asignaturaEquivalentes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignaturaEquivalentes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAsignaturaEquivalente"] = new SelectList(_context.Asignaturas, "Id", "Curso", asignaturaEquivalentes.IdAsignaturaEquivalente);
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "Id", "Curso", asignaturaEquivalentes.IdAsignatura);
            return View(asignaturaEquivalentes);
        }

        // GET: AsignaturaEquivalentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturaEquivalentes = await _context.AsignaturaEquivalentes.FindAsync(id);
            if (asignaturaEquivalentes == null)
            {
                return NotFound();
            }
            ViewData["IdAsignaturaEquivalente"] = new SelectList(_context.Asignaturas, "Id", "Curso", asignaturaEquivalentes.IdAsignaturaEquivalente);
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "Id", "Curso", asignaturaEquivalentes.IdAsignatura);
            return View(asignaturaEquivalentes);
        }

        // POST: AsignaturaEquivalentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAsignatura,IdAsignaturaEquivalente")] AsignaturaEquivalentes asignaturaEquivalentes)
        {
            if (id != asignaturaEquivalentes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignaturaEquivalentes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturaEquivalentesExists(asignaturaEquivalentes.Id))
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
            ViewData["IdAsignaturaEquivalente"] = new SelectList(_context.Asignaturas, "Id", "Curso", asignaturaEquivalentes.IdAsignaturaEquivalente);
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "Id", "Curso", asignaturaEquivalentes.IdAsignatura);
            return View(asignaturaEquivalentes);
        }

        // GET: AsignaturaEquivalentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturaEquivalentes = await _context.AsignaturaEquivalentes
                .Include(a => a.IdAsignaturaEquivalenteNavigation)
                .Include(a => a.IdAsignaturaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignaturaEquivalentes == null)
            {
                return NotFound();
            }

            return View(asignaturaEquivalentes);
        }

        // POST: AsignaturaEquivalentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignaturaEquivalentes = await _context.AsignaturaEquivalentes.FindAsync(id);
            _context.AsignaturaEquivalentes.Remove(asignaturaEquivalentes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturaEquivalentesExists(int id)
        {
            return _context.AsignaturaEquivalentes.Any(e => e.Id == id);
        }
    }
}
