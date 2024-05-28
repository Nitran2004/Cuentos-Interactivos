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
    public class Peli5Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Peli5Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Peli5
        public async Task<IActionResult> Index()
        {
              return _context.Peli5 != null ? 
                          View(await _context.Peli5.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Peli5'  is null.");
        }

        // GET: Peli5/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Peli5 == null)
            {
                return NotFound();
            }

            var peli5 = await _context.Peli5
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli5 == null)
            {
                return NotFound();
            }

            return View(peli5);
        }

        // GET: Peli5/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peli5/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Peli5 peli5)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peli5);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peli5);
        }

        // GET: Peli5/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Peli5 == null)
            {
                return NotFound();
            }

            var peli5 = await _context.Peli5.FindAsync(id);
            if (peli5 == null)
            {
                return NotFound();
            }
            return View(peli5);
        }

        // POST: Peli5/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Peli5 peli5)
        {
            if (id != peli5.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peli5);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Peli5Exists(peli5.ID))
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
            return View(peli5);
        }

        // GET: Peli5/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Peli5 == null)
            {
                return NotFound();
            }

            var peli5 = await _context.Peli5
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli5 == null)
            {
                return NotFound();
            }

            return View(peli5);
        }

        // POST: Peli5/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Peli5 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Peli5'  is null.");
            }
            var peli5 = await _context.Peli5.FindAsync(id);
            if (peli5 != null)
            {
                _context.Peli5.Remove(peli5);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Peli5Exists(int id)
        {
          return (_context.Peli5?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
