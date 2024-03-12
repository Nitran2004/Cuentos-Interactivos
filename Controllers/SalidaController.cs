using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecureAssetManager.Data;
using SecureAssetManager.Models;

namespace SecureAssetManager.Controllers
{
    public class SalidaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalidaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Salida
        public async Task<IActionResult> Index()
        {
              return _context.Salida != null ? 
                          View(await _context.Salida.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Salida'  is null.");
        }

        // GET: Salida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salida == null)
            {
                return NotFound();
            }

            var salida = await _context.Salida
                .FirstOrDefaultAsync(m => m.ID == id);
            if (salida == null)
            {
                return NotFound();
            }

            return View(salida);
        }

        // GET: Salida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Salida salida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salida);
        }

        // GET: Salida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salida == null)
            {
                return NotFound();
            }

            var salida = await _context.Salida.FindAsync(id);
            if (salida == null)
            {
                return NotFound();
            }
            return View(salida);
        }

        // POST: Salida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Salida salida)
        {
            if (id != salida.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalidaExists(salida.ID))
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
            return View(salida);
        }

        // GET: Salida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salida == null)
            {
                return NotFound();
            }

            var salida = await _context.Salida
                .FirstOrDefaultAsync(m => m.ID == id);
            if (salida == null)
            {
                return NotFound();
            }

            return View(salida);
        }

        // POST: Salida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salida == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Salida'  is null.");
            }
            var salida = await _context.Salida.FindAsync(id);
            if (salida != null)
            {
                _context.Salida.Remove(salida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalidaExists(int id)
        {
          return (_context.Salida?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
