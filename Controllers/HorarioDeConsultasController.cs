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
    public class HorarioDeConsultasController : Controller
    {
        private readonly StudentServiceContext _context;

        public HorarioDeConsultasController(StudentServiceContext context)
        {
            _context = context;
        }

        // GET: HorarioDeConsultas
        public async Task<IActionResult> Index()
        {
            var studentServiceContext = _context.HorarioDeConsultas.Include(h => h.IdProfesorNavigation);
            return View(await studentServiceContext.ToListAsync());
        }

        // GET: HorarioDeConsultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioDeConsultas = await _context.HorarioDeConsultas
                .Include(h => h.IdProfesorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horarioDeConsultas == null)
            {
                return NotFound();
            }

            return View(horarioDeConsultas);
        }

        // GET: HorarioDeConsultas/Create
        public IActionResult Create()
        {
            ViewData["IdProfesor"] = new SelectList(_context.Profesores, "Id", "Despacho");
            return View();
        }

        // POST: HorarioDeConsultas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dia,Hora,IdProfesor")] HorarioDeConsultas horarioDeConsultas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horarioDeConsultas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProfesor"] = new SelectList(_context.Profesores, "Id", "Despacho", horarioDeConsultas.IdProfesor);
            return View(horarioDeConsultas);
        }

        // GET: HorarioDeConsultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioDeConsultas = await _context.HorarioDeConsultas.FindAsync(id);
            if (horarioDeConsultas == null)
            {
                return NotFound();
            }
            ViewData["IdProfesor"] = new SelectList(_context.Profesores, "Id", "Despacho", horarioDeConsultas.IdProfesor);
            return View(horarioDeConsultas);
        }

        // POST: HorarioDeConsultas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dia,Hora,IdProfesor")] HorarioDeConsultas horarioDeConsultas)
        {
            if (id != horarioDeConsultas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horarioDeConsultas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioDeConsultasExists(horarioDeConsultas.Id))
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
            ViewData["IdProfesor"] = new SelectList(_context.Profesores, "Id", "Despacho", horarioDeConsultas.IdProfesor);
            return View(horarioDeConsultas);
        }

        // GET: HorarioDeConsultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioDeConsultas = await _context.HorarioDeConsultas
                .Include(h => h.IdProfesorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horarioDeConsultas == null)
            {
                return NotFound();
            }

            return View(horarioDeConsultas);
        }

        // POST: HorarioDeConsultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horarioDeConsultas = await _context.HorarioDeConsultas.FindAsync(id);
            _context.HorarioDeConsultas.Remove(horarioDeConsultas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioDeConsultasExists(int id)
        {
            return _context.HorarioDeConsultas.Any(e => e.Id == id);
        }
    }
}
