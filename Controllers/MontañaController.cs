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
    public class MontañaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MontañaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Montaña
        public async Task<IActionResult> Index()
        {
              return _context.Montaña != null ? 
                          View(await _context.Montaña.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Montaña'  is null.");
        }

        // GET: Montaña/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Montaña == null)
            {
                return NotFound();
            }

            var montaña = await _context.Montaña
                .FirstOrDefaultAsync(m => m.ID == id);
            if (montaña == null)
            {
                return NotFound();
            }

            return View(montaña);
        }

        // GET: Montaña/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Montaña/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Montaña montaña)
        {
            if (ModelState.IsValid)
            {
                _context.Add(montaña);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(montaña);
        }

        // GET: Montaña/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Montaña == null)
            {
                return NotFound();
            }

            var montaña = await _context.Montaña.FindAsync(id);
            if (montaña == null)
            {
                return NotFound();
            }
            return View(montaña);
        }

        // POST: Montaña/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Montaña montaña)
        {
            if (id != montaña.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(montaña);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MontañaExists(montaña.ID))
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
            return View(montaña);
        }

        // GET: Montaña/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Montaña == null)
            {
                return NotFound();
            }

            var montaña = await _context.Montaña
                .FirstOrDefaultAsync(m => m.ID == id);
            if (montaña == null)
            {
                return NotFound();
            }

            return View(montaña);
        }

        // POST: Montaña/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Montaña == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Montaña'  is null.");
            }
            var montaña = await _context.Montaña.FindAsync(id);
            if (montaña != null)
            {
                _context.Montaña.Remove(montaña);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MontañaExists(int id)
        {
          return (_context.Montaña?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
