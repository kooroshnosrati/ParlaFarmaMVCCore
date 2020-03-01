using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParlaFarmaMVCCore.API;
using ParlaFarmaMVCCore.Data;
using ParlaFarmaMVCCore.Models;
using ParlaFarmaMVCCore.ViewModels;

namespace ParlaFarmaMVCCore.Areas.CPanel.Controllers
{
    [Authorize]
    [Area("CPanel")]
    public class SlidersController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;

        public SlidersController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: CPanel/Sliders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tbl_Sliders.ToListAsync());
        }

        // GET: CPanel/Sliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Sliders = await _context.Tbl_Sliders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Sliders == null)
            {
                return NotFound();
            }

            return View(Sliders);
        }

        // GET: CPanel/Sliders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CPanel/Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(vmdl_Slider newSlider) //[Bind("Lang,Image,Title1,Title2,Title3,ButtonText,ButtonLink")] 
        {
            cls_UploadDownloadFiles cls_UploadDownloadFiles = new cls_UploadDownloadFiles();
            if (ModelState.IsValid)
            {
                string uniqueFileName = cls_UploadDownloadFiles.UploadedFile(_webHostEnvironment.WebRootPath, newSlider.Image);

                Slider slider = new Slider
                {
                    Lang = newSlider.Lang,
                    Image = uniqueFileName,
                    Title1 = newSlider.Title1,
                    Title2 = newSlider.Title2,
                    Title3 = newSlider.Title3,
                    ButtonText = newSlider.ButtonText,
                    ButtonLink = newSlider.ButtonLink
                };

                _context.Add(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Cpanel/Sliders");
            }
            return View(newSlider);
        }

        private  vmdl_Slider ConvertSliderToViewModel(int? id)
        {
            Slider slider = _context.Tbl_Sliders.Find(id);
            if (slider == null)
            {
                return null;
            }

            vmdl_Slider vmdl_Slider = new vmdl_Slider
            {
                Id = slider.Id,
                Lang = slider.Lang,
                Title1 = slider.Title1,
                Title2 = slider.Title2,
                Title3 = slider.Title3,
                ButtonText = slider.ButtonText,
                ButtonLink = slider.ButtonLink,
                ImageStr = slider.Image
            };
            return vmdl_Slider;
        }
        // GET: CPanel/Sliders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            vmdl_Slider vmdl_Slider = ConvertSliderToViewModel(id);

            return View(vmdl_Slider);
        }

        // POST: CPanel/Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, vmdl_Slider updateSlider) //[Bind("Id,Lang,Image,Title1,Title2,Title3,ButtonText,ButtonLink")]
        {
            cls_UploadDownloadFiles cls_UploadDownloadFiles = new cls_UploadDownloadFiles();
            if (id != updateSlider.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueFileName = cls_UploadDownloadFiles.UploadedFile(_webHostEnvironment.WebRootPath, updateSlider.Image);

                    Slider slider = new Slider
                    {
                        Lang = updateSlider.Lang,
                        Image = uniqueFileName,
                        Title1 = updateSlider.Title1,
                        Title2 = updateSlider.Title2,
                        Title3 = updateSlider.Title3,
                        ButtonText = updateSlider.ButtonText,
                        ButtonLink = updateSlider.ButtonLink
                    };

                    _context.Update(slider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsSliderExists(updateSlider.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Cpanel/Sliders");
            }

            vmdl_Slider vmdl_Slider = ConvertSliderToViewModel(id);
            return View(vmdl_Slider);
        }

        // GET: CPanel/Sliders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Tbl_Sliders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // POST: CPanel/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slider = await _context.Tbl_Sliders.FindAsync(id);
            _context.Tbl_Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Cpanel/Sliders");
        }

        private bool IsSliderExists(int id)
        {
            return _context.Tbl_Sliders.Any(e => e.Id == id);
        }

    }
}
