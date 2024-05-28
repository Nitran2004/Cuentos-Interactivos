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
    public class Peli6Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Peli6Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Peli6
        public async Task<IActionResult> Index()
        {
              return _context.Peli6 != null ? 
                          View(await _context.Peli6.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Peli6'  is null.");
        }

        // GET: Peli6/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Peli6 == null)
            {
                return NotFound();
            }

            var peli6 = await _context.Peli6
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli6 == null)
            {
                return NotFound();
            }

            return View(peli6);
        }

        // GET: Peli6/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peli6/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Peli6 peli6)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peli6);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peli6);
        }

        // GET: Peli6/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Peli6 == null)
            {
                return NotFound();
            }

            var peli6 = await _context.Peli6.FindAsync(id);
            if (peli6 == null)
            {
                return NotFound();
            }
            return View(peli6);
        }

        // POST: Peli6/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Peli6 peli6)
        {
            if (id != peli6.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peli6);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Peli6Exists(peli6.ID))
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
            return View(peli6);
        }

        // GET: Peli6/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Peli6 == null)
            {
                return NotFound();
            }

            var peli6 = await _context.Peli6
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli6 == null)
            {
                return NotFound();
            }

            return View(peli6);
        }

        // POST: Peli6/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Peli6 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Peli6'  is null.");
            }
            var peli6 = await _context.Peli6.FindAsync(id);
            if (peli6 != null)
            {
                _context.Peli6.Remove(peli6);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Peli6Exists(int id)
        {
          return (_context.Peli6?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
