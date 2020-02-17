using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ParlaFarmaMVCCore.Models;
using ParlaFarmaMVCCore.API;


namespace ParlaFarmaMVCCore.Areas.EN.Controllers
{
    [Area("EN")]
    //[Route("EN/[controller]/[action]")]
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactUs([FromForm]mdl_ContactUsIno mdl_ContactUsIno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cls_MailManagement cls_MailManagement = new cls_MailManagement();
                    cls_MailManagement.To.Add(new cls_emailAccount("Koorosh.nosrati@live.com", "Kourosh Nosrati Heravi"));
                    cls_MailManagement.To.Add(new cls_emailAccount("valeh.farid@parlapharma.com", "Valeh Parla"));
                    cls_MailManagement.To.Add(new cls_emailAccount("Info@parlapharma.com", "Info User of Parla Pharma"));
                    cls_MailManagement.Subject = "Parla Pharma Contact US Page : " + mdl_ContactUsIno.Subject;
                    cls_MailManagement.Body = string.Format("Dear Ino User : {6} Mr./Miss {0} Has Sent you an email through Contact Us Page. {6} His/Her Name : {1} " +
                                                "{6} Phone Number : {2} {6} Email : {3} {6} Subject : {4} {6} Message Body : {6} {5}", mdl_ContactUsIno.FullName, mdl_ContactUsIno.FullName, mdl_ContactUsIno.PhoneNumber, mdl_ContactUsIno.Email, mdl_ContactUsIno.Subject, mdl_ContactUsIno.MessageBody, Environment.NewLine );
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
    }
}