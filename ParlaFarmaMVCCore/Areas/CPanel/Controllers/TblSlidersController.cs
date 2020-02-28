using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParlaFarmaMVCCore.Data;
using ParlaFarmaMVCCore.Models;

namespace ParlaFarmaMVCCore.Areas.CPanel.Controllers
{
    [Authorize]
    [Area("CPanel")]
    public class TblSlidersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TblSlidersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CPanel/TblSliders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tbl_Sliders.ToListAsync());
        }

        // GET: CPanel/TblSliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSliders = await _context.Tbl_Sliders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblSliders == null)
            {
                return NotFound();
            }

            return View(tblSliders);
        }

        // GET: CPanel/TblSliders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CPanel/TblSliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Lang,Image,Title1,Title2,Title3,ButtonText,ButtonLink")] TblSliders tblSliders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblSliders);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Cpanel/tblSliders");
            }
            return View(tblSliders);
        }

        // GET: CPanel/TblSliders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSliders = await _context.Tbl_Sliders.FindAsync(id);
            if (tblSliders == null)
            {
                return NotFound();
            }
            return View(tblSliders);
        }

        // POST: CPanel/TblSliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Lang,Image,Title1,Title2,Title3,ButtonText,ButtonLink")] TblSliders tblSliders)
        {
            if (id != tblSliders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSliders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSlidersExists(tblSliders.Id))
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
            return View(tblSliders);
        }

        // GET: CPanel/TblSliders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSliders = await _context.Tbl_Sliders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblSliders == null)
            {
                return NotFound();
            }

            return View(tblSliders);
        }

        // POST: CPanel/TblSliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblSliders = await _context.Tbl_Sliders.FindAsync(id);
            _context.Tbl_Sliders.Remove(tblSliders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSlidersExists(int id)
        {
            return _context.Tbl_Sliders.Any(e => e.Id == id);
        }
    }
}
