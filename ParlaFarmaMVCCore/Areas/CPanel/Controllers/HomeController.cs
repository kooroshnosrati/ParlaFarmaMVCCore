﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ParlaFarmaMVCCore.Areas.CPanel.Controllers
{
    [Area("CPanel")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return RedirectToAction("Index", "Home", new { Area=""});
            return View();
        }
    }
}