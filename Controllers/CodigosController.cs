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
    public class CodigosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CodigosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Codigos
        public async Task<IActionResult> Index()
        {
              return _context.Codigo != null ? 
                          View(await _context.Codigo.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Codigo'  is null.");
        }

        // GET: Codigos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Codigo == null)
            {
                return NotFound();
            }

            var codigo = await _context.Codigo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (codigo == null)
            {
                return NotFound();
            }

            return View(codigo);
        }

        // GET: Codigos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Codigos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TipoControl,Efectividad")] Codigo codigo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codigo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codigo);
        }

        // GET: Codigos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Codigo == null)
            {
                return NotFound();
            }

            var codigo = await _context.Codigo.FindAsync(id);
            if (codigo == null)
            {
                return NotFound();
            }
            return View(codigo);
        }

        // POST: Codigos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TipoControl,Efectividad")] Codigo codigo)
        {
            if (id != codigo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codigo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodigoExists(codigo.ID))
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
            return View(codigo);
        }

        // GET: Codigos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Codigo == null)
            {
                return NotFound();
            }

            var codigo = await _context.Codigo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (codigo == null)
            {
                return NotFound();
            }

            return View(codigo);
        }

        // POST: Codigos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Codigo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Codigo'  is null.");
            }
            var codigo = await _context.Codigo.FindAsync(id);
            if (codigo != null)
            {
                _context.Codigo.Remove(codigo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodigoExists(int id)
        {
          return (_context.Codigo?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
