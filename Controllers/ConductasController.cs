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
    public class ConductasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConductasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Conductas
        public async Task<IActionResult> Index()
        {
              return _context.Conducta != null ? 
                          View(await _context.Conducta.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Conducta'  is null.");
        }

        // GET: Conductas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conducta == null)
            {
                return NotFound();
            }

            var conducta = await _context.Conducta
                .FirstOrDefaultAsync(m => m.ID == id);
            if (conducta == null)
            {
                return NotFound();
            }

            return View(conducta);
        }

        // GET: Conductas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conductas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Conducta conducta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conducta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conducta);
        }

        // GET: Conductas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conducta == null)
            {
                return NotFound();
            }

            var conducta = await _context.Conducta.FindAsync(id);
            if (conducta == null)
            {
                return NotFound();
            }
            return View(conducta);
        }

        // POST: Conductas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Conducta conducta)
        {
            if (id != conducta.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conducta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConductaExists(conducta.ID))
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
            return View(conducta);
        }

        // GET: Conductas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conducta == null)
            {
                return NotFound();
            }

            var conducta = await _context.Conducta
                .FirstOrDefaultAsync(m => m.ID == id);
            if (conducta == null)
            {
                return NotFound();
            }

            return View(conducta);
        }

        // POST: Conductas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conducta == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Conducta'  is null.");
            }
            var conducta = await _context.Conducta.FindAsync(id);
            if (conducta != null)
            {
                _context.Conducta.Remove(conducta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConductaExists(int id)
        {
          return (_context.Conducta?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
