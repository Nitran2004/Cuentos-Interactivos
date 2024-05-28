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
    public class Peli7Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Peli7Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Peli7
        public async Task<IActionResult> Index()
        {
              return _context.Peli7 != null ? 
                          View(await _context.Peli7.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Peli7'  is null.");
        }

        // GET: Peli7/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Peli7 == null)
            {
                return NotFound();
            }

            var peli7 = await _context.Peli7
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli7 == null)
            {
                return NotFound();
            }

            return View(peli7);
        }

        // GET: Peli7/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peli7/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Peli7 peli7)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peli7);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peli7);
        }

        // GET: Peli7/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Peli7 == null)
            {
                return NotFound();
            }

            var peli7 = await _context.Peli7.FindAsync(id);
            if (peli7 == null)
            {
                return NotFound();
            }
            return View(peli7);
        }

        // POST: Peli7/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Peli7 peli7)
        {
            if (id != peli7.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peli7);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Peli7Exists(peli7.ID))
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
            return View(peli7);
        }

        // GET: Peli7/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Peli7 == null)
            {
                return NotFound();
            }

            var peli7 = await _context.Peli7
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli7 == null)
            {
                return NotFound();
            }

            return View(peli7);
        }

        // POST: Peli7/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Peli7 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Peli7'  is null.");
            }
            var peli7 = await _context.Peli7.FindAsync(id);
            if (peli7 != null)
            {
                _context.Peli7.Remove(peli7);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Peli7Exists(int id)
        {
          return (_context.Peli7?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
