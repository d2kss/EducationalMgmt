﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EducationalInstitute.Data;
using EducationalInstitute.Models;

namespace EducationalInstitute.Controllers
{
    public class FeesController : Controller
    {
        private readonly EducationalInstituteContext _context;

        public FeesController(EducationalInstituteContext context)
        {
            _context = context;
        }

        // GET: Fees
        public async Task<IActionResult> Index()
        {
            var educationalInstituteContext = _context.Fees.Include(f => f.SClass);
            return View(await educationalInstituteContext.ToListAsync());
        }

        // GET: Fees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fees = await _context.Fees
                .Include(f => f.SClass)
                .FirstOrDefaultAsync(m => m.FeesId == id);
            if (fees == null)
            {
                return NotFound();
            }

            return View(fees);
        }

        // GET: Fees/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.SClass, "ClassId", "ClassName");
            return View();
        }

        // POST: Fees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeesId,Amount,ClassId")] Fees fees)
        {
            if (ModelState.IsValid)
            {
                fees.IsActive = 'Y';
                fees.CreatedBy = "Admin";
                fees.CreatedDate=DateTime.Now;
                _context.Add(fees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.SClass, "ClassId", "ClassName", fees.ClassId);
            return View(fees);
        }

        // GET: Fees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fees = await _context.Fees.FindAsync(id);
            if (fees == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.SClass, "ClassId", "ClassName", fees.ClassId);
            return View(fees);
        }

        // POST: Fees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeesId,Amount,ClassId")] Fees fees)
        {
            if (id != fees.FeesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    fees.UpdatedBy = "Admin";
                    fees.UpdatedDate= DateTime.Now;
                    _context.Update(fees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeesExists(fees.FeesId))
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
            ViewData["ClassId"] = new SelectList(_context.SClass, "ClassId", "ClassName", fees.ClassId);
            return View(fees);
        }

        // GET: Fees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fees = await _context.Fees
                .Include(f => f.SClass)
                .FirstOrDefaultAsync(m => m.FeesId == id);
            if (fees == null)
            {
                return NotFound();
            }

            return View(fees);
        }

        // POST: Fees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fees = await _context.Fees.FindAsync(id);
            if (fees != null)
            {
                _context.Fees.Remove(fees);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeesExists(int id)
        {
            return _context.Fees.Any(e => e.FeesId == id);
        }
    }
}
