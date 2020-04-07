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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ParlaFarmaMVCCore.Areas.EN.Controllers
{
    [Area("EN")]
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        //private readonly ApplicationDbContext _context;
        public HomeController(IWebHostEnvironment webHostEnvironment) //ApplicationDbContext applicationDbContext, 
        {
            //_context = applicationDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            try
            {
                string kk = $"{ this.Request.PathBase }";
                ViewBag.PageURL = $"{this.Request.Scheme}://{this.Request.Host}/EN/Home/Index"; 
                ViewBag.PageID = "Index";
                //List <Slider> sliders = new List<Slider>();
                //foreach (Slider item in _context.Tbl_Sliders.Where(m => m.Lang == 1))
                //{
                //    sliders.Add(item);
                //}
                //ViewBag.sliders = sliders.ToList();
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult AboutUs()
        {
            ViewBag.PageURL = $"{this.Request.Scheme}://{this.Request.Host}/EN/Home/AboutUs"; 
            ViewBag.PageID = "AboutUs";
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
            ViewBag.PageID = "Partners";
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
                    cls_MailManagement.Body = string.Format("Dear Info User : {6} Mr./Miss {0} Has Sent you an email through Contact Us Page. {6} His/Her Name : {1} " +
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Applicationform(vmdl_ApplicationForm vmdl_ApplicationForm)
        {
            string AttachmentfilePath = "";
            bool hasAttachment = false;
            string ResumeStr = $"{this.Request.Scheme}://{this.Request.Host}/Uploads/"; // {this.Request.PathBase}";
            string uniqueResumeFileName = "";
            cls_UploadDownloadFiles cls_UploadDownloadFiles = new cls_UploadDownloadFiles();
            if (ModelState.IsValid)
            {
                if (vmdl_ApplicationForm.ResumeFile != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
                    uniqueResumeFileName = cls_UploadDownloadFiles.UploadedFile(
                        _webHostEnvironment.WebRootPath,
                        vmdl_ApplicationForm.ResumeFile);
                    AttachmentfilePath = Path.Combine(uploadsFolder, uniqueResumeFileName);
                    ResumeStr += uniqueResumeFileName;
                    hasAttachment = true;
                }
                else if (vmdl_ApplicationForm.ResumeURL != null && vmdl_ApplicationForm.ResumeURL.Length > 0)
                {
                    ResumeStr = vmdl_ApplicationForm.ResumeURL;
                }

                cls_MailManagement cls_MailManagement = new cls_MailManagement();
                cls_MailManagement.To.Add(new cls_emailAccount("Koorosh.nosrati@live.com", "Kourosh Nosrati Heravi"));
                cls_MailManagement.To.Add(new cls_emailAccount("valeh.farid@parlapharma.com", "Valeh Parla"));
                cls_MailManagement.To.Add(new cls_emailAccount("Info@parlapharma.com", "Info User of Parla Pharma"));
                cls_MailManagement.Subject = "Parla Pharma Application Form Page" ;
                if (hasAttachment)
                    cls_MailManagement.Attachments.Add(AttachmentfilePath);
                cls_MailManagement.Body = string.Format(
                    "Dear Info User : {7} Mr./Miss {0} Has Sent you an email through Application Form Page.{7}" +
                    "His/Her Name : {0} {7} Phone Number : {1} {7} Email : {2} {7} Available Start Date : {3} {7} " +
                    "Emplyment Status : {4} {7} He/She Apply's for {5} {7} His/Her Resume : {6} {7}", 
                    vmdl_ApplicationForm.FirstName + " " + vmdl_ApplicationForm.LastName, 
                    vmdl_ApplicationForm.Phone, 
                    vmdl_ApplicationForm.Email,
                    vmdl_ApplicationForm.AvailableStartDate,
                    vmdl_ApplicationForm.EmploymentStatus,
                    vmdl_ApplicationForm.JobTitle,
                    ResumeStr,
                    Environment.NewLine);
                cls_MailManagement.SendEmail();
            }
            return View();
        }
        public IActionResult OurValues()
        {
            return View();
        }
    }
}