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
    public class Mito4Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Mito4Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mito4
        public async Task<IActionResult> Index()
        {
              return _context.Mito4 != null ? 
                          View(await _context.Mito4.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Mito4'  is null.");
        }

        // GET: Mito4/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mito4 == null)
            {
                return NotFound();
            }

            var mito4 = await _context.Mito4
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mito4 == null)
            {
                return NotFound();
            }

            return View(mito4);
        }

        // GET: Mito4/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mito4/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Mito4 mito4)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mito4);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mito4);
        }

        // GET: Mito4/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mito4 == null)
            {
                return NotFound();
            }

            var mito4 = await _context.Mito4.FindAsync(id);
            if (mito4 == null)
            {
                return NotFound();
            }
            return View(mito4);
        }

        // POST: Mito4/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Mito4 mito4)
        {
            if (id != mito4.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mito4);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mito4Exists(mito4.ID))
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
            return View(mito4);
        }

        // GET: Mito4/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mito4 == null)
            {
                return NotFound();
            }

            var mito4 = await _context.Mito4
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mito4 == null)
            {
                return NotFound();
            }

            return View(mito4);
        }

        // POST: Mito4/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mito4 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mito4'  is null.");
            }
            var mito4 = await _context.Mito4.FindAsync(id);
            if (mito4 != null)
            {
                _context.Mito4.Remove(mito4);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mito4Exists(int id)
        {
          return (_context.Mito4?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
