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

        public IActionResult ContactUs()
        {
            return View();
        }

    }
}