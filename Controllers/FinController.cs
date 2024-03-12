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
    public class FinController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FinController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fin
        public async Task<IActionResult> Index()
        {
              return _context.Fin != null ? 
                          View(await _context.Fin.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Fin'  is null.");
        }

        // GET: Fin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fin == null)
            {
                return NotFound();
            }

            var fin = await _context.Fin
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fin == null)
            {
                return NotFound();
            }

            return View(fin);
        }

        // GET: Fin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Fin fin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fin);
        }

        // GET: Fin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fin == null)
            {
                return NotFound();
            }

            var fin = await _context.Fin.FindAsync(id);
            if (fin == null)
            {
                return NotFound();
            }
            return View(fin);
        }

        // POST: Fin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Fin fin)
        {
            if (id != fin.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinExists(fin.ID))
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
            return View(fin);
        }

        // GET: Fin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fin == null)
            {
                return NotFound();
            }

            var fin = await _context.Fin
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fin == null)
            {
                return NotFound();
            }

            return View(fin);
        }

        // POST: Fin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fin == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Fin'  is null.");
            }
            var fin = await _context.Fin.FindAsync(id);
            if (fin != null)
            {
                _context.Fin.Remove(fin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinExists(int id)
        {
          return (_context.Fin?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
