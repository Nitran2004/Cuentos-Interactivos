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
    public class Peli3Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Peli3Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Peli3
        public async Task<IActionResult> Index()
        {
              return _context.Peli3 != null ? 
                          View(await _context.Peli3.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Peli3'  is null.");
        }

        // GET: Peli3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Peli3 == null)
            {
                return NotFound();
            }

            var peli3 = await _context.Peli3
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli3 == null)
            {
                return NotFound();
            }

            return View(peli3);
        }

        // GET: Peli3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peli3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Peli3 peli3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peli3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peli3);
        }

        // GET: Peli3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Peli3 == null)
            {
                return NotFound();
            }

            var peli3 = await _context.Peli3.FindAsync(id);
            if (peli3 == null)
            {
                return NotFound();
            }
            return View(peli3);
        }

        // POST: Peli3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Peli3 peli3)
        {
            if (id != peli3.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peli3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Peli3Exists(peli3.ID))
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
            return View(peli3);
        }

        // GET: Peli3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Peli3 == null)
            {
                return NotFound();
            }

            var peli3 = await _context.Peli3
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli3 == null)
            {
                return NotFound();
            }

            return View(peli3);
        }

        // POST: Peli3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Peli3 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Peli3'  is null.");
            }
            var peli3 = await _context.Peli3.FindAsync(id);
            if (peli3 != null)
            {
                _context.Peli3.Remove(peli3);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Peli3Exists(int id)
        {
          return (_context.Peli3?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
