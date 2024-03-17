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
    public class RusasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RusasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rusas
        public async Task<IActionResult> Index()
        {
              return _context.Rusa != null ? 
                          View(await _context.Rusa.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Rusa'  is null.");
        }

        // GET: Rusas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rusa == null)
            {
                return NotFound();
            }

            var rusa = await _context.Rusa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rusa == null)
            {
                return NotFound();
            }

            return View(rusa);
        }

        // GET: Rusas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rusas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Rusa rusa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rusa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rusa);
        }

        // GET: Rusas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rusa == null)
            {
                return NotFound();
            }

            var rusa = await _context.Rusa.FindAsync(id);
            if (rusa == null)
            {
                return NotFound();
            }
            return View(rusa);
        }

        // POST: Rusas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Rusa rusa)
        {
            if (id != rusa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rusa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RusaExists(rusa.ID))
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
            return View(rusa);
        }

        // GET: Rusas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rusa == null)
            {
                return NotFound();
            }

            var rusa = await _context.Rusa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rusa == null)
            {
                return NotFound();
            }

            return View(rusa);
        }

        // POST: Rusas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rusa == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Rusa'  is null.");
            }
            var rusa = await _context.Rusa.FindAsync(id);
            if (rusa != null)
            {
                _context.Rusa.Remove(rusa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RusaExists(int id)
        {
          return (_context.Rusa?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
