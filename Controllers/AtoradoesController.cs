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
    public class AtoradoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AtoradoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Atoradoes
        public async Task<IActionResult> Index()
        {
              return _context.Atorado != null ? 
                          View(await _context.Atorado.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Atorado'  is null.");
        }

        // GET: Atoradoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Atorado == null)
            {
                return NotFound();
            }

            var atorado = await _context.Atorado
                .FirstOrDefaultAsync(m => m.ID == id);
            if (atorado == null)
            {
                return NotFound();
            }

            return View(atorado);
        }

        // GET: Atoradoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atoradoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Atorado atorado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atorado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atorado);
        }

        // GET: Atoradoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Atorado == null)
            {
                return NotFound();
            }

            var atorado = await _context.Atorado.FindAsync(id);
            if (atorado == null)
            {
                return NotFound();
            }
            return View(atorado);
        }

        // POST: Atoradoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Atorado atorado)
        {
            if (id != atorado.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atorado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtoradoExists(atorado.ID))
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
            return View(atorado);
        }

        // GET: Atoradoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Atorado == null)
            {
                return NotFound();
            }

            var atorado = await _context.Atorado
                .FirstOrDefaultAsync(m => m.ID == id);
            if (atorado == null)
            {
                return NotFound();
            }

            return View(atorado);
        }

        // POST: Atoradoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Atorado == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Atorado'  is null.");
            }
            var atorado = await _context.Atorado.FindAsync(id);
            if (atorado != null)
            {
                _context.Atorado.Remove(atorado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtoradoExists(int id)
        {
          return (_context.Atorado?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
