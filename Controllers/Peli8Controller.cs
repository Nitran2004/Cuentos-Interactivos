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
    public class Peli8Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Peli8Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Peli8
        public async Task<IActionResult> Index()
        {
              return _context.Peli8 != null ? 
                          View(await _context.Peli8.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Peli8'  is null.");
        }

        // GET: Peli8/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Peli8 == null)
            {
                return NotFound();
            }

            var peli8 = await _context.Peli8
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli8 == null)
            {
                return NotFound();
            }

            return View(peli8);
        }

        // GET: Peli8/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peli8/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Peli8 peli8)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peli8);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peli8);
        }

        // GET: Peli8/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Peli8 == null)
            {
                return NotFound();
            }

            var peli8 = await _context.Peli8.FindAsync(id);
            if (peli8 == null)
            {
                return NotFound();
            }
            return View(peli8);
        }

        // POST: Peli8/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Peli8 peli8)
        {
            if (id != peli8.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peli8);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Peli8Exists(peli8.ID))
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
            return View(peli8);
        }

        // GET: Peli8/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Peli8 == null)
            {
                return NotFound();
            }

            var peli8 = await _context.Peli8
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli8 == null)
            {
                return NotFound();
            }

            return View(peli8);
        }

        // POST: Peli8/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Peli8 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Peli8'  is null.");
            }
            var peli8 = await _context.Peli8.FindAsync(id);
            if (peli8 != null)
            {
                _context.Peli8.Remove(peli8);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Peli8Exists(int id)
        {
          return (_context.Peli8?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
