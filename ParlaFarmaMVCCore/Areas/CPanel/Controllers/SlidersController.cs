using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        public async Task<IActionResult> Create([Bind("Lang,Image,Title1,Title2,Title3,ButtonText,ButtonLink")] vmdl_Slider newSlider)
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

        // GET: CPanel/Sliders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Tbl_Sliders.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }
            return View(slider);
        }

        // POST: CPanel/Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Lang,Image,Title1,Title2,Title3,ButtonText,ButtonLink")] Slider slider)
        {
            if (id != slider.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsSliderExists(slider.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
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
            return RedirectToAction(nameof(Index));
        }

        private bool IsSliderExists(int id)
        {
            return _context.Tbl_Sliders.Any(e => e.Id == id);
        }

    }
}
