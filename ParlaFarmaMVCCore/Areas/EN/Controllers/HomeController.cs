using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ParlaFarmaMVCCore.Areas.EN.Controllers
{
    [Area("EN")]
    [Route("EN/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {

            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
        public IActionResult PressCenter()
        {
            return View();
        }
        public IActionResult Partners()
        {
            return View();
        }
        public IActionResult Career()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Applicationform()
        {
            return View();
        }
        public IActionResult ExportDevelopment()
        {
            return View();
        }
        public IActionResult Distributors()
        {
            return View();
        }
        

    }
}