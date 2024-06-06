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
    public class Gato7Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Gato7Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gato7
        public async Task<IActionResult> Index()
        {
              return _context.Gato7 != null ? 
                          View(await _context.Gato7.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Gato7'  is null.");
        }

        // GET: Gato7/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gato7 == null)
            {
                return NotFound();
            }

            var gato7 = await _context.Gato7
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gato7 == null)
            {
                return NotFound();
            }

            return View(gato7);
        }

        // GET: Gato7/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gato7/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Gato7 gato7)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gato7);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gato7);
        }

        // GET: Gato7/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gato7 == null)
            {
                return NotFound();
            }

            var gato7 = await _context.Gato7.FindAsync(id);
            if (gato7 == null)
            {
                return NotFound();
            }
            return View(gato7);
        }

        // POST: Gato7/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Gato7 gato7)
        {
            if (id != gato7.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gato7);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Gato7Exists(gato7.ID))
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
            return View(gato7);
        }

        // GET: Gato7/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gato7 == null)
            {
                return NotFound();
            }

            var gato7 = await _context.Gato7
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gato7 == null)
            {
                return NotFound();
            }

            return View(gato7);
        }

        // POST: Gato7/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gato7 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Gato7'  is null.");
            }
            var gato7 = await _context.Gato7.FindAsync(id);
            if (gato7 != null)
            {
                _context.Gato7.Remove(gato7);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Gato7Exists(int id)
        {
          return (_context.Gato7?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
