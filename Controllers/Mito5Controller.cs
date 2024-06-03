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
    public class Mito5Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Mito5Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mito5
        public async Task<IActionResult> Index()
        {
              return _context.Mito5 != null ? 
                          View(await _context.Mito5.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Mito5'  is null.");
        }

        // GET: Mito5/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mito5 == null)
            {
                return NotFound();
            }

            var mito5 = await _context.Mito5
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mito5 == null)
            {
                return NotFound();
            }

            return View(mito5);
        }

        // GET: Mito5/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mito5/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Mito5 mito5)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mito5);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mito5);
        }

        // GET: Mito5/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mito5 == null)
            {
                return NotFound();
            }

            var mito5 = await _context.Mito5.FindAsync(id);
            if (mito5 == null)
            {
                return NotFound();
            }
            return View(mito5);
        }

        // POST: Mito5/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Mito5 mito5)
        {
            if (id != mito5.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mito5);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mito5Exists(mito5.ID))
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
            return View(mito5);
        }

        // GET: Mito5/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mito5 == null)
            {
                return NotFound();
            }

            var mito5 = await _context.Mito5
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mito5 == null)
            {
                return NotFound();
            }

            return View(mito5);
        }

        // POST: Mito5/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mito5 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mito5'  is null.");
            }
            var mito5 = await _context.Mito5.FindAsync(id);
            if (mito5 != null)
            {
                _context.Mito5.Remove(mito5);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mito5Exists(int id)
        {
          return (_context.Mito5?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
