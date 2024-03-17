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
    public class VictoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VictoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Victorias
        public async Task<IActionResult> Index()
        {
              return _context.Victoria != null ? 
                          View(await _context.Victoria.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Victoria'  is null.");
        }

        // GET: Victorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Victoria == null)
            {
                return NotFound();
            }

            var victoria = await _context.Victoria
                .FirstOrDefaultAsync(m => m.ID == id);
            if (victoria == null)
            {
                return NotFound();
            }

            return View(victoria);
        }

        // GET: Victorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Victorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Victoria victoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(victoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(victoria);
        }

        // GET: Victorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Victoria == null)
            {
                return NotFound();
            }

            var victoria = await _context.Victoria.FindAsync(id);
            if (victoria == null)
            {
                return NotFound();
            }
            return View(victoria);
        }

        // POST: Victorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Victoria victoria)
        {
            if (id != victoria.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(victoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VictoriaExists(victoria.ID))
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
            return View(victoria);
        }

        // GET: Victorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Victoria == null)
            {
                return NotFound();
            }

            var victoria = await _context.Victoria
                .FirstOrDefaultAsync(m => m.ID == id);
            if (victoria == null)
            {
                return NotFound();
            }

            return View(victoria);
        }

        // POST: Victorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Victoria == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Victoria'  is null.");
            }
            var victoria = await _context.Victoria.FindAsync(id);
            if (victoria != null)
            {
                _context.Victoria.Remove(victoria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VictoriaExists(int id)
        {
          return (_context.Victoria?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
