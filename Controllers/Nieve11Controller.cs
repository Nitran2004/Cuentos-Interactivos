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
    public class Nieve11Controller : Controller
    {


        // GET: Nieve11/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Ibdex()
        {
            return View();
        }
    }
}
