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
    public class MapasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MapasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mapas
        public async Task<IActionResult> Index()
        {
              return _context.Mapa != null ? 
                          View(await _context.Mapa.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Mapa'  is null.");
        }

        // GET: Mapas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mapa == null)
            {
                return NotFound();
            }

            var mapa = await _context.Mapa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mapa == null)
            {
                return NotFound();
            }

            return View(mapa);
        }

        // GET: Mapas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mapas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Mapa mapa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mapa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mapa);
        }

        // GET: Mapas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mapa == null)
            {
                return NotFound();
            }

            var mapa = await _context.Mapa.FindAsync(id);
            if (mapa == null)
            {
                return NotFound();
            }
            return View(mapa);
        }

        // POST: Mapas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Mapa mapa)
        {
            if (id != mapa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mapa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MapaExists(mapa.ID))
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
            return View(mapa);
        }

        // GET: Mapas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mapa == null)
            {
                return NotFound();
            }

            var mapa = await _context.Mapa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mapa == null)
            {
                return NotFound();
            }

            return View(mapa);
        }

        // POST: Mapas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mapa == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mapa'  is null.");
            }
            var mapa = await _context.Mapa.FindAsync(id);
            if (mapa != null)
            {
                _context.Mapa.Remove(mapa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MapaExists(int id)
        {
          return (_context.Mapa?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
