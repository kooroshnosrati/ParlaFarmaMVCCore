using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ParlaFarmaMVCCore.Models;


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
                if (!ModelState.IsValid)
                {
                    SmtpClient smtpClient = new SmtpClient("mail.parlapharma.com", 587);

                    smtpClient.Credentials = new System.Net.NetworkCredential("info@parlapharma.com", "qEgqNSOSs4kp");
                    // smtpClient.UseDefaultCredentials = true; // uncomment if you don't want to use the network credentials
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //smtpClient.EnableSsl = true;
                    MailMessage mail = new MailMessage();

                    //Setting From , To and CC
                    mail.From = new MailAddress("info@parlapharma.com", "info@parlapharma.com");
                    mail.To.Add(new MailAddress("Koorosh.nosrati@live.com"));
                    mail.CC.Add(new MailAddress("valeh.farid@parlapharma.com"));
                    //mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));
                    //string bodyStr = string.Format("Dear Ino User : \n\r Mr./Miss {0} Has Sent you an email through Contact Us Page. His/Her Name : {1} " +
                    //    "\n\r Phone Number : {2} \n\r Email : {3} \n\r Subject : {4} \n\r Message Body : {5}", modelContactVar.FullName, modelContactVar.FullName, modelContactVar.PhoneNumber, modelContactVar.ContactEmail, modelContactVar.Subject, modelContactVar.MessageBody);
                    string bodyStr = "";
                    mail.Body = bodyStr;
                    smtpClient.Send(mail);
                }
            }
            catch (Exception)
            {
                ;
            }
            return null;//RedirectToAction("ContactUs", "Home");
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