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
    public class Mito1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Mito1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mito1
        public async Task<IActionResult> Index()
        {
              return _context.Mito1 != null ? 
                          View(await _context.Mito1.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Mito1'  is null.");
        }

        // GET: Mito1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mito1 == null)
            {
                return NotFound();
            }

            var mito1 = await _context.Mito1
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mito1 == null)
            {
                return NotFound();
            }

            return View(mito1);
        }

        // GET: Mito1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mito1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Mito1 mito1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mito1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mito1);
        }

        // GET: Mito1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mito1 == null)
            {
                return NotFound();
            }

            var mito1 = await _context.Mito1.FindAsync(id);
            if (mito1 == null)
            {
                return NotFound();
            }
            return View(mito1);
        }

        // POST: Mito1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Mito1 mito1)
        {
            if (id != mito1.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mito1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mito1Exists(mito1.ID))
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
            return View(mito1);
        }

        // GET: Mito1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mito1 == null)
            {
                return NotFound();
            }

            var mito1 = await _context.Mito1
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mito1 == null)
            {
                return NotFound();
            }

            return View(mito1);
        }

        // POST: Mito1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mito1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mito1'  is null.");
            }
            var mito1 = await _context.Mito1.FindAsync(id);
            if (mito1 != null)
            {
                _context.Mito1.Remove(mito1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mito1Exists(int id)
        {
          return (_context.Mito1?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
