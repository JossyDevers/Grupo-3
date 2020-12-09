using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentService.Models;

// Prueba

namespace StudentService.Controllers
{
    public class AreasController : Controller
    {
        private readonly StudentServiceContext _context;

        public AreasController(StudentServiceContext context)
        {
            _context = context;
        }

        // GET: Areas
        public async Task<IActionResult> Index()
        {
            var studentServiceContext = _context.Areas.Include(a => a.IdDepartamentoNavigation);
            return View(await studentServiceContext.ToListAsync());
        }

        // GET: Areas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areas = await _context.Areas
                .Include(a => a.IdDepartamentoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areas == null)
            {
                return NotFound();
            }

            return View(areas);
        }

        // GET: Areas/Create
        public IActionResult Create()
        {
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "Id", "Nombre");
            return View();
        }

        // POST: Areas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,IdDepartamento")] Areas areas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "Id", "Nombre", areas.IdDepartamento);
            return View(areas);
        }

        // GET: Areas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areas = await _context.Areas.FindAsync(id);
            if (areas == null)
            {
                return NotFound();
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "Id", "Nombre", areas.IdDepartamento);
            return View(areas);
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,IdDepartamento")] Areas areas)
        {
            if (id != areas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreasExists(areas.Id))
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
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "Id", "Nombre", areas.IdDepartamento);
            return View(areas);
        }

        // GET: Areas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areas = await _context.Areas
                .Include(a => a.IdDepartamentoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areas == null)
            {
                return NotFound();
            }

            return View(areas);
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var areas = await _context.Areas.FindAsync(id);
            _context.Areas.Remove(areas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreasExists(int id)
        {
            return _context.Areas.Any(e => e.Id == id);
        }
        public IActionResult Menu()
        {
            return View();
        }
    }
}
