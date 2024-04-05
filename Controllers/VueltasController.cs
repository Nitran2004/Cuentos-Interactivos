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
    public class VueltasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VueltasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vueltas/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string accion)
        {
            if (accion == "Página siguiente")
            {

                return RedirectToAction("Create", "Descensos");
            }
            return View();
        }
    }
}
