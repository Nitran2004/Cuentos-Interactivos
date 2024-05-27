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
    public class Alpez6Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Alpez6Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alpez6
        public async Task<IActionResult> Index()
        {
              return _context.Alpez6 != null ? 
                          View(await _context.Alpez6.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Alpez6'  is null.");
        }

        // GET: Alpez6/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alpez6 == null)
            {
                return NotFound();
            }

            var alpez6 = await _context.Alpez6
                .FirstOrDefaultAsync(m => m.ID == id);
            if (alpez6 == null)
            {
                return NotFound();
            }

            return View(alpez6);
        }

        // GET: Alpez6/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alpez6/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Alpez6 alpez6)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alpez6);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alpez6);
        }

        // GET: Alpez6/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alpez6 == null)
            {
                return NotFound();
            }

            var alpez6 = await _context.Alpez6.FindAsync(id);
            if (alpez6 == null)
            {
                return NotFound();
            }
            return View(alpez6);
        }

        // POST: Alpez6/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Alpez6 alpez6)
        {
            if (id != alpez6.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alpez6);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Alpez6Exists(alpez6.ID))
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
            return View(alpez6);
        }

        // GET: Alpez6/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alpez6 == null)
            {
                return NotFound();
            }

            var alpez6 = await _context.Alpez6
                .FirstOrDefaultAsync(m => m.ID == id);
            if (alpez6 == null)
            {
                return NotFound();
            }

            return View(alpez6);
        }

        // POST: Alpez6/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alpez6 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Alpez6'  is null.");
            }
            var alpez6 = await _context.Alpez6.FindAsync(id);
            if (alpez6 != null)
            {
                _context.Alpez6.Remove(alpez6);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Alpez6Exists(int id)
        {
          return (_context.Alpez6?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
