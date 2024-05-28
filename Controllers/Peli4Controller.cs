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
    public class Peli4Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Peli4Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Peli4
        public async Task<IActionResult> Index()
        {
              return _context.Peli4 != null ? 
                          View(await _context.Peli4.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Peli4'  is null.");
        }

        // GET: Peli4/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Peli4 == null)
            {
                return NotFound();
            }

            var peli4 = await _context.Peli4
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli4 == null)
            {
                return NotFound();
            }

            return View(peli4);
        }

        // GET: Peli4/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peli4/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Peli4 peli4)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peli4);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peli4);
        }

        // GET: Peli4/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Peli4 == null)
            {
                return NotFound();
            }

            var peli4 = await _context.Peli4.FindAsync(id);
            if (peli4 == null)
            {
                return NotFound();
            }
            return View(peli4);
        }

        // POST: Peli4/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Peli4 peli4)
        {
            if (id != peli4.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peli4);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Peli4Exists(peli4.ID))
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
            return View(peli4);
        }

        // GET: Peli4/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Peli4 == null)
            {
                return NotFound();
            }

            var peli4 = await _context.Peli4
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli4 == null)
            {
                return NotFound();
            }

            return View(peli4);
        }

        // POST: Peli4/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Peli4 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Peli4'  is null.");
            }
            var peli4 = await _context.Peli4.FindAsync(id);
            if (peli4 != null)
            {
                _context.Peli4.Remove(peli4);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Peli4Exists(int id)
        {
          return (_context.Peli4?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
