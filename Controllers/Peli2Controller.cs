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
    public class Peli2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Peli2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Peli2
        public async Task<IActionResult> Index()
        {
              return _context.Peli2 != null ? 
                          View(await _context.Peli2.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Peli2'  is null.");
        }

        // GET: Peli2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Peli2 == null)
            {
                return NotFound();
            }

            var peli2 = await _context.Peli2
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli2 == null)
            {
                return NotFound();
            }

            return View(peli2);
        }

        // GET: Peli2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peli2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Peli2 peli2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peli2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peli2);
        }

        // GET: Peli2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Peli2 == null)
            {
                return NotFound();
            }

            var peli2 = await _context.Peli2.FindAsync(id);
            if (peli2 == null)
            {
                return NotFound();
            }
            return View(peli2);
        }

        // POST: Peli2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Peli2 peli2)
        {
            if (id != peli2.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peli2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Peli2Exists(peli2.ID))
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
            return View(peli2);
        }

        // GET: Peli2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Peli2 == null)
            {
                return NotFound();
            }

            var peli2 = await _context.Peli2
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli2 == null)
            {
                return NotFound();
            }

            return View(peli2);
        }

        // POST: Peli2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Peli2 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Peli2'  is null.");
            }
            var peli2 = await _context.Peli2.FindAsync(id);
            if (peli2 != null)
            {
                _context.Peli2.Remove(peli2);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Peli2Exists(int id)
        {
          return (_context.Peli2?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
