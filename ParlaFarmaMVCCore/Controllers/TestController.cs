using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParlaFarmaMVCCore.Models;

namespace ParlaFarmaMVCCore.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(mdl_ContactUsIno mdl_ContactUsIno)
        {

            string kk = mdl_ContactUsIno.FullName;
            return View();
        }
    }
}