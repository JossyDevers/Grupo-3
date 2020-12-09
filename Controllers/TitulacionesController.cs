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
    public class TitulacionesController : Controller
    {
        private readonly StudentServiceContext _context;

        public TitulacionesController(StudentServiceContext context)
        {
            _context = context;
        }

        // GET: Titulaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Titulaciones.ToListAsync());
        }

        // GET: Titulaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titulaciones = await _context.Titulaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (titulaciones == null)
            {
                return NotFound();
            }

            return View(titulaciones);
        }

        // GET: Titulaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Titulaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Titulaciones titulaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(titulaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(titulaciones);
        }

        // GET: Titulaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titulaciones = await _context.Titulaciones.FindAsync(id);
            if (titulaciones == null)
            {
                return NotFound();
            }
            return View(titulaciones);
        }

        // POST: Titulaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Titulaciones titulaciones)
        {
            if (id != titulaciones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(titulaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TitulacionesExists(titulaciones.Id))
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
            return View(titulaciones);
        }

        // GET: Titulaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titulaciones = await _context.Titulaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (titulaciones == null)
            {
                return NotFound();
            }

            return View(titulaciones);
        }

        // POST: Titulaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var titulaciones = await _context.Titulaciones.FindAsync(id);
            _context.Titulaciones.Remove(titulaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TitulacionesExists(int id)
        {
            return _context.Titulaciones.Any(e => e.Id == id);
        }
    }
}
