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
    public class AsignaturaIncompatiblesController : Controller
    {
        private readonly StudentServiceContext _context;

        public AsignaturaIncompatiblesController(StudentServiceContext context)
        {
            _context = context;
        }

        // GET: AsignaturaIncompatibles
        public async Task<IActionResult> Index()
        {
            var studentServiceContext = _context.AsignaturaIncompatibles.Include(a => a.IdAsignaturaIncompatibleNavigation).Include(a => a.IdAsignaturaNavigation);
            return View(await studentServiceContext.ToListAsync());
        }

        // GET: AsignaturaIncompatibles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturaIncompatibles = await _context.AsignaturaIncompatibles
                .Include(a => a.IdAsignaturaIncompatibleNavigation)
                .Include(a => a.IdAsignaturaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignaturaIncompatibles == null)
            {
                return NotFound();
            }

            return View(asignaturaIncompatibles);
        }

        // GET: AsignaturaIncompatibles/Create
        public IActionResult Create()
        {
            ViewData["IdAsignaturaIncompatible"] = new SelectList(_context.Asignaturas, "Id", "Curso");
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "Id", "Curso");
            return View();
        }

        // POST: AsignaturaIncompatibles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdAsignatura,IdAsignaturaIncompatible")] AsignaturaIncompatibles asignaturaIncompatibles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignaturaIncompatibles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAsignaturaIncompatible"] = new SelectList(_context.Asignaturas, "Id", "Curso", asignaturaIncompatibles.IdAsignaturaIncompatible);
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "Id", "Curso", asignaturaIncompatibles.IdAsignatura);
            return View(asignaturaIncompatibles);
        }

        // GET: AsignaturaIncompatibles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturaIncompatibles = await _context.AsignaturaIncompatibles.FindAsync(id);
            if (asignaturaIncompatibles == null)
            {
                return NotFound();
            }
            ViewData["IdAsignaturaIncompatible"] = new SelectList(_context.Asignaturas, "Id", "Curso", asignaturaIncompatibles.IdAsignaturaIncompatible);
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "Id", "Curso", asignaturaIncompatibles.IdAsignatura);
            return View(asignaturaIncompatibles);
        }

        // POST: AsignaturaIncompatibles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAsignatura,IdAsignaturaIncompatible")] AsignaturaIncompatibles asignaturaIncompatibles)
        {
            if (id != asignaturaIncompatibles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignaturaIncompatibles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturaIncompatiblesExists(asignaturaIncompatibles.Id))
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
            ViewData["IdAsignaturaIncompatible"] = new SelectList(_context.Asignaturas, "Id", "Curso", asignaturaIncompatibles.IdAsignaturaIncompatible);
            ViewData["IdAsignatura"] = new SelectList(_context.Asignaturas, "Id", "Curso", asignaturaIncompatibles.IdAsignatura);
            return View(asignaturaIncompatibles);
        }

        // GET: AsignaturaIncompatibles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturaIncompatibles = await _context.AsignaturaIncompatibles
                .Include(a => a.IdAsignaturaIncompatibleNavigation)
                .Include(a => a.IdAsignaturaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignaturaIncompatibles == null)
            {
                return NotFound();
            }

            return View(asignaturaIncompatibles);
        }

        // POST: AsignaturaIncompatibles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignaturaIncompatibles = await _context.AsignaturaIncompatibles.FindAsync(id);
            _context.AsignaturaIncompatibles.Remove(asignaturaIncompatibles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturaIncompatiblesExists(int id)
        {
            return _context.AsignaturaIncompatibles.Any(e => e.Id == id);
        }
    }
}
