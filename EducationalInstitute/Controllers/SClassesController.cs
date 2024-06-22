using System;
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
    public class SClassesController : Controller
    {
        private readonly EducationalInstituteContext _context;

        public SClassesController(EducationalInstituteContext context)
        {
            _context = context;
        }

        // GET: SClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.SClass.ToListAsync());
        }

        // GET: SClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sClass = await _context.SClass
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (sClass == null)
            {
                return NotFound();
            }

            return View(sClass);
        }

        // GET: SClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassId,ClassName")] SClass sClass)
        {
            if (ModelState.IsValid)
            {
                sClass.IsActive = 'Y';
                sClass.CreatedBy = "Admin";
                sClass.CreatedDate = DateTime.Now;
                _context.Add(sClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sClass);
        }

        // GET: SClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sClass = await _context.SClass.FindAsync(id);
            if (sClass == null)
            {
                return NotFound();
            }
            return View(sClass);
        }

        // POST: SClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassId,ClassName")] SClass sClass)
        {
            if (id != sClass.ClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    sClass.UpdatedBy = "Admin";
                    sClass.UpdatedDate = DateTime.Now;  
                    _context.Update(sClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SClassExists(sClass.ClassId))
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
            return View(sClass);
        }

        // GET: SClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sClass = await _context.SClass
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (sClass == null)
            {
                return NotFound();
            }

            return View(sClass);
        }

        // POST: SClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sClass = await _context.SClass.FindAsync(id);
            if (sClass != null)
            {
                _context.SClass.Remove(sClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SClassExists(int id)
        {
            return _context.SClass.Any(e => e.ClassId == id);
        }
    }
}
