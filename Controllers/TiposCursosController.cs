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
    public class TiposCursosController : Controller
    {
        private readonly StudentServiceContext _context;

        public TiposCursosController(StudentServiceContext context)
        {
            _context = context;
        }

        // GET: TiposCursos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposCursos.ToListAsync());
        }

        // GET: TiposCursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposCursos = await _context.TiposCursos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposCursos == null)
            {
                return NotFound();
            }

            return View(tiposCursos);
        }

        // GET: TiposCursos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposCursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] TiposCursos tiposCursos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposCursos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposCursos);
        }

        // GET: TiposCursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposCursos = await _context.TiposCursos.FindAsync(id);
            if (tiposCursos == null)
            {
                return NotFound();
            }
            return View(tiposCursos);
        }

        // POST: TiposCursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] TiposCursos tiposCursos)
        {
            if (id != tiposCursos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposCursos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposCursosExists(tiposCursos.Id))
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
            return View(tiposCursos);
        }

        // GET: TiposCursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposCursos = await _context.TiposCursos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposCursos == null)
            {
                return NotFound();
            }

            return View(tiposCursos);
        }

        // POST: TiposCursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposCursos = await _context.TiposCursos.FindAsync(id);
            _context.TiposCursos.Remove(tiposCursos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposCursosExists(int id)
        {
            return _context.TiposCursos.Any(e => e.Id == id);
        }
    }
}
