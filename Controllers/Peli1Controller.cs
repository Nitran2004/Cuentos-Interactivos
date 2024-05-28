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
    public class Peli1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Peli1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Peli1
        public async Task<IActionResult> Index()
        {
              return _context.Peli1 != null ? 
                          View(await _context.Peli1.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Peli1'  is null.");
        }

        // GET: Peli1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Peli1 == null)
            {
                return NotFound();
            }

            var peli1 = await _context.Peli1
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli1 == null)
            {
                return NotFound();
            }

            return View(peli1);
        }

        // GET: Peli1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peli1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Peli1 peli1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peli1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peli1);
        }

        // GET: Peli1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Peli1 == null)
            {
                return NotFound();
            }

            var peli1 = await _context.Peli1.FindAsync(id);
            if (peli1 == null)
            {
                return NotFound();
            }
            return View(peli1);
        }

        // POST: Peli1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Peli1 peli1)
        {
            if (id != peli1.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peli1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Peli1Exists(peli1.ID))
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
            return View(peli1);
        }

        // GET: Peli1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Peli1 == null)
            {
                return NotFound();
            }

            var peli1 = await _context.Peli1
                .FirstOrDefaultAsync(m => m.ID == id);
            if (peli1 == null)
            {
                return NotFound();
            }

            return View(peli1);
        }

        // POST: Peli1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Peli1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Peli1'  is null.");
            }
            var peli1 = await _context.Peli1.FindAsync(id);
            if (peli1 != null)
            {
                _context.Peli1.Remove(peli1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Peli1Exists(int id)
        {
          return (_context.Peli1?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
