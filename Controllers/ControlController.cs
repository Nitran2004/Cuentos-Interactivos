﻿using Microsoft.AspNetCore.Mvc;
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
    public class ControlController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        SoundPlayer player = new SoundPlayer();
        string[] canciones = { "Canciones/Ejemplo.wav", "Canciones/Ejemplo2.wav" };
        int posicion = 0;
        public ControlController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Controls.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string accion)
        {
            if (accion == "Página siguiente" && this.posicion < this.canciones.Length)
            {
                this.posicion += 1;
                this.player = new SoundPlayer(this.canciones[this.posicion]);
                player.LoadAsync();
                player.PlaySync();
                return RedirectToAction("Index", "Risk");
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
