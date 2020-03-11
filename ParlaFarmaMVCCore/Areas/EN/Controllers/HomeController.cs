using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ParlaFarmaMVCCore.Models;
using ParlaFarmaMVCCore.API;
using ParlaFarmaMVCCore.Data;
using ParlaFarmaMVCCore.ViewModels;

namespace ParlaFarmaMVCCore.Areas.EN.Controllers
{
    [Area("EN")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public IActionResult Index(int? id, string ScrollId, int ScrollAmount, bool URLRequested)
        {
            try
            {
                ViewBag.ScrollAmount = ScrollAmount;
                ViewBag.PageID = "Index";
                if (ScrollId != null)
                    ViewBag.TagID = ScrollId;
                else
                    ViewBag.TagID = "";
                ViewBag.URLRequested = URLRequested;
                List <Slider> sliders = new List<Slider>();
                foreach (Slider item in _context.Tbl_Sliders.Where(m => m.Lang == 1))
                {
                    sliders.Add(item);
                }
                ViewBag.sliders = sliders.ToList();
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult AboutUs(int? id, string ScrollId, int ScrollAmount, bool URLRequested)
        {
            ViewBag.ScrollAmount = ScrollAmount;
            ViewBag.PageID = "AboutUs";
            if (ScrollId != null)
                ViewBag.TagID = ScrollId;
            else
                ViewBag.TagID = "";
            ViewBag.URLRequested = URLRequested;
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
            ViewBag.PageID = "Career";
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactUs([FromForm]vmdl_ContactUsIno vmdl_ContactUsIno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cls_MailManagement cls_MailManagement = new cls_MailManagement();
                    cls_MailManagement.To.Add(new cls_emailAccount("Koorosh.nosrati@live.com", "Kourosh Nosrati Heravi"));
                    cls_MailManagement.To.Add(new cls_emailAccount("valeh.farid@parlapharma.com", "Valeh Parla"));
                    cls_MailManagement.To.Add(new cls_emailAccount("Info@parlapharma.com", "Info User of Parla Pharma"));
                    cls_MailManagement.Subject = "Parla Pharma Contact US Page : " + vmdl_ContactUsIno.Subject;
                    cls_MailManagement.Body = string.Format("Dear Ino User : {6} Mr./Miss {0} Has Sent you an email through Contact Us Page. {6} His/Her Name : {1} " +
                                                "{6} Phone Number : {2} {6} Email : {3} {6} Subject : {4} {6} Message Body : {6} {5}", vmdl_ContactUsIno.FullName, vmdl_ContactUsIno.FullName, vmdl_ContactUsIno.PhoneNumber, vmdl_ContactUsIno.Email, vmdl_ContactUsIno.Subject, vmdl_ContactUsIno.MessageBody, Environment.NewLine );
                    cls_MailManagement.SendEmail();
                }
            }
            catch (Exception)
            {
                ;
            }
            return RedirectToAction("ContactUs", "EN/Home");
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
        public IActionResult ParlaCulture()
        {
            return View();
        }
        public IActionResult OurValues()
        {
            return View();
        }
    }
}