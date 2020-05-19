﻿using System;
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
    public class DictionariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictionariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CPanel/Dictionaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tbl_Dictionary.ToListAsync());
        }

        // GET: CPanel/Dictionaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionary = await _context.Tbl_Dictionary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictionary == null)
            {
                return NotFound();
            }

            return View(dictionary);
        }

        // GET: CPanel/Dictionaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CPanel/Dictionaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EN,AZ,RU")] Dictionary dictionary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictionary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictionary);
        }

        // GET: CPanel/Dictionaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionary = await _context.Tbl_Dictionary.FindAsync(id);
            if (dictionary == null)
            {
                return NotFound();
            }
            return View(dictionary);
        }

        // POST: CPanel/Dictionaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EN,AZ,RU")] Dictionary dictionary)
        {
            if (id != dictionary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictionary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictionaryExists(dictionary.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Cpanel/Dictionaries");
            }
            return View(dictionary);
        }

        // GET: CPanel/Dictionaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionary = await _context.Tbl_Dictionary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictionary == null)
            {
                return NotFound();
            }

            return View(dictionary);
        }

        // POST: CPanel/Dictionaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictionary = await _context.Tbl_Dictionary.FindAsync(id);
            _context.Tbl_Dictionary.Remove(dictionary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictionaryExists(int id)
        {
            return _context.Tbl_Dictionary.Any(e => e.Id == id);
        }
    }
}
