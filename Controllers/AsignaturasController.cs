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
    public class AsignaturasController : Controller
    {
        private readonly StudentServiceContext _context;

        public AsignaturasController(StudentServiceContext context)
        {
            _context = context;
        }

        // GET: Asignaturas
        public async Task<IActionResult> Index()
        {
            var studentServiceContext = _context.Asignaturas.Include(a => a.IdAreaNavigation).Include(a => a.IdProfesorNavigation).Include(a => a.IdTitulacionNavigation);
            return View(await studentServiceContext.ToListAsync());
        }

        // GET: Asignaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturas = await _context.Asignaturas
                .Include(a => a.IdAreaNavigation)
                .Include(a => a.IdCursoNavigation)
                .Include(a => a.IdProfesorNavigation)
                .Include(a => a.IdTitulacionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignaturas == null)
            {
                return NotFound();
            }

            return View(asignaturas);
        }

        // GET: Asignaturas/Create
        public IActionResult Create()
        {
            ViewData["IdArea"] = new SelectList(_context.Areas, "Id", "Nombre");
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Curso");
            ViewData["IdProfesor"] = new SelectList(_context.Profesores, "Id", "Despacho");
            ViewData["IdTitulacion"] = new SelectList(_context.Titulaciones, "Id", "Nombre");
            return View();
        }

        // POST: Asignaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Numero,Tipo,Curso,Duracion,CreditosTeoricos,CreditosPracticos,GruposTeoricos,GruposPracticos,LibConf,LimAdm,IdProfesor,IdArea,IdTitulacion")] Asignaturas asignaturas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignaturas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArea"] = new SelectList(_context.Areas, "Id", "Nombre", asignaturas.IdArea);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Curso", asignaturas.IdCurso);
            ViewData["IdProfesor"] = new SelectList(_context.Profesores, "Id", "Despacho", asignaturas.IdProfesor);
            ViewData["IdTitulacion"] = new SelectList(_context.Titulaciones, "Id", "Nombre", asignaturas.IdTitulacion);
            return View(asignaturas);
        }

        // GET: Asignaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturas = await _context.Asignaturas.FindAsync(id);
            if (asignaturas == null)
            {
                return NotFound();
            }
            ViewData["IdArea"] = new SelectList(_context.Areas, "Id", "Nombre", asignaturas.IdArea);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Curso", asignaturas.IdCurso);
            ViewData["IdProfesor"] = new SelectList(_context.Profesores, "Id", "Despacho", asignaturas.IdProfesor);
            ViewData["IdTitulacion"] = new SelectList(_context.Titulaciones, "Id", "Nombre", asignaturas.IdTitulacion);
            return View(asignaturas);
        }

        // POST: Asignaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Numero,Tipo,Duracion,CreditosTeoricos,CreditosPracticos,GruposTeoricos,GruposPracticos,LibConf,LimAdm,IdProfesor,IdArea,IdCurso,IdTitulacion")] Asignaturas asignaturas)
        {
            if (id != asignaturas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignaturas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturasExists(asignaturas.Id))
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
            ViewData["IdArea"] = new SelectList(_context.Areas, "Id", "Nombre", asignaturas.IdArea);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Curso", asignaturas.IdCurso);
            ViewData["IdProfesor"] = new SelectList(_context.Profesores, "Id", "Despacho", asignaturas.IdProfesor);
            ViewData["IdTitulacion"] = new SelectList(_context.Titulaciones, "Id", "Nombre", asignaturas.IdTitulacion);
            return View(asignaturas);
        }

        // GET: Asignaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturas = await _context.Asignaturas
                .Include(a => a.IdAreaNavigation)
                .Include(a => a.IdCursoNavigation)
                .Include(a => a.IdProfesorNavigation)
                .Include(a => a.IdTitulacionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignaturas == null)
            {
                return NotFound();
            }

            return View(asignaturas);
        }

        // POST: Asignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignaturas = await _context.Asignaturas.FindAsync(id);
            _context.Asignaturas.Remove(asignaturas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturasExists(int id)
        {
            return _context.Asignaturas.Any(e => e.Id == id);
        }
        public IActionResult Menu()
        {
            return View();
        }
    }
}
