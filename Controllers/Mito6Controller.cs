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
    public class Mito6Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Mito6Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mito6
        public async Task<IActionResult> Index()
        {
              return _context.Mito6 != null ? 
                          View(await _context.Mito6.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Mito6'  is null.");
        }

        // GET: Mito6/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mito6 == null)
            {
                return NotFound();
            }

            var mito6 = await _context.Mito6
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mito6 == null)
            {
                return NotFound();
            }

            return View(mito6);
        }

        // GET: Mito6/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mito6/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Mito6 mito6)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mito6);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mito6);
        }

        // GET: Mito6/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mito6 == null)
            {
                return NotFound();
            }

            var mito6 = await _context.Mito6.FindAsync(id);
            if (mito6 == null)
            {
                return NotFound();
            }
            return View(mito6);
        }

        // POST: Mito6/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Mito6 mito6)
        {
            if (id != mito6.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mito6);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mito6Exists(mito6.ID))
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
            return View(mito6);
        }

        // GET: Mito6/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mito6 == null)
            {
                return NotFound();
            }

            var mito6 = await _context.Mito6
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mito6 == null)
            {
                return NotFound();
            }

            return View(mito6);
        }

        // POST: Mito6/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mito6 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mito6'  is null.");
            }
            var mito6 = await _context.Mito6.FindAsync(id);
            if (mito6 != null)
            {
                _context.Mito6.Remove(mito6);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mito6Exists(int id)
        {
          return (_context.Mito6?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
