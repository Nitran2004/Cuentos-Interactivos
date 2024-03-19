using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecureAssetManager.Data;
using SecureAssetManager.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Media;

namespace SecureAssetManager.Controllers
{
    public class ThreatController : Controller
    {
        private readonly ApplicationDbContext _context;
		private readonly ILogger<HomeController> _logger;

		SoundPlayer player = new SoundPlayer();
		string[] canciones = { "Canciones/Ejemplo.wav", "Canciones/Ejemplo2.wav" }; 
        int posicion = 0;

		public ThreatController(ApplicationDbContext context, ILogger<HomeController> logger)
		{
			_context = context;
			_logger = logger;
		}

        public async Task<IActionResult> Index()
        {
            return View(await _context.Threats.ToListAsync());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var threat = await _context.Threats.FirstOrDefaultAsync(m => m.Id == id);
            if (threat == null)
            {
                return NotFound();
            }

            return View(threat);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var threat = await _context.Threats.FindAsync(id);
            if (threat == null)
            {
                return NotFound();
            }
            return View(threat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ThreatOrigin,ThreatDescription,Degradation,Probability")] Threat threat)
        {
            if (id != threat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(threat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThreatExists(threat.Id))
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
            return View(threat);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var threat = await _context.Threats.FirstOrDefaultAsync(m => m.Id == id);
            if (threat == null)
            {
                return NotFound();
            }

            return View(threat);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var threat = await _context.Threats.FindAsync(id);
            _context.Threats.Remove(threat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThreatExists(int id)
        {
            return _context.Threats.Any(e => e.Id == id);
        }

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(string accion)
		{
			if (accion == "Página anterior")
			{
				this.player = new SoundPlayer(this.canciones[this.posicion]);
				this.player.LoadAsync();
				this.player.PlaySync();
			}
			if (accion == "Página siguiente" && this.posicion < this.canciones.Length)
			{
				this.posicion += 1;
				this.player = new SoundPlayer(this.canciones[this.posicion]);
				player.LoadAsync();
				player.PlaySync();
			}
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}



	}
}
