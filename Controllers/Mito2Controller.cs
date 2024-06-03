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
    public class Mito2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Mito2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mito2
        public async Task<IActionResult> Index()
        {
              return _context.Mito2 != null ? 
                          View(await _context.Mito2.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Mito2'  is null.");
        }

        // GET: Mito2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mito2 == null)
            {
                return NotFound();
            }

            var mito2 = await _context.Mito2
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mito2 == null)
            {
                return NotFound();
            }

            return View(mito2);
        }

        // GET: Mito2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mito2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Mito2 mito2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mito2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mito2);
        }

        // GET: Mito2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mito2 == null)
            {
                return NotFound();
            }

            var mito2 = await _context.Mito2.FindAsync(id);
            if (mito2 == null)
            {
                return NotFound();
            }
            return View(mito2);
        }

        // POST: Mito2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Mito2 mito2)
        {
            if (id != mito2.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mito2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mito2Exists(mito2.ID))
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
            return View(mito2);
        }

        // GET: Mito2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mito2 == null)
            {
                return NotFound();
            }

            var mito2 = await _context.Mito2
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mito2 == null)
            {
                return NotFound();
            }

            return View(mito2);
        }

        // POST: Mito2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mito2 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mito2'  is null.");
            }
            var mito2 = await _context.Mito2.FindAsync(id);
            if (mito2 != null)
            {
                _context.Mito2.Remove(mito2);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mito2Exists(int id)
        {
          return (_context.Mito2?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
