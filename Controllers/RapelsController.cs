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
    public class RapelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RapelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Rapels/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Rapels/Create
        public IActionResult Index()
        {
            return View();
        }
    }
}
