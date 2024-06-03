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
    public class Mito3Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Mito3Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mito3
        public async Task<IActionResult> Index()
        {
              return _context.Mito3 != null ? 
                          View(await _context.Mito3.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Mito3'  is null.");
        }

        // GET: Mito3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mito3 == null)
            {
                return NotFound();
            }

            var mito3 = await _context.Mito3
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mito3 == null)
            {
                return NotFound();
            }

            return View(mito3);
        }

        // GET: Mito3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mito3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Mito3 mito3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mito3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mito3);
        }

        // GET: Mito3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mito3 == null)
            {
                return NotFound();
            }

            var mito3 = await _context.Mito3.FindAsync(id);
            if (mito3 == null)
            {
                return NotFound();
            }
            return View(mito3);
        }

        // POST: Mito3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Mito3 mito3)
        {
            if (id != mito3.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mito3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mito3Exists(mito3.ID))
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
            return View(mito3);
        }

        // GET: Mito3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mito3 == null)
            {
                return NotFound();
            }

            var mito3 = await _context.Mito3
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mito3 == null)
            {
                return NotFound();
            }

            return View(mito3);
        }

        // POST: Mito3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mito3 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mito3'  is null.");
            }
            var mito3 = await _context.Mito3.FindAsync(id);
            if (mito3 != null)
            {
                _context.Mito3.Remove(mito3);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mito3Exists(int id)
        {
          return (_context.Mito3?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
