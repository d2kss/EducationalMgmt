using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EducationalInstitute.Data;
using EducationalInstitute.Models;
using EducationalInstitute.Repository.Interface;

namespace EducationalInstitute.Controllers
{
    public class SectionsController : Controller
    {
        private readonly IUnitOfWork _context;

        public SectionsController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: Sections
        public async Task<IActionResult> Index()
        {
            return View(_context.SectionRepository.GetAll().ToList());
        }

        // GET: Sections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = _context.SectionRepository
                .Get(m => m.SectionId == id);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // GET: Sections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SectionId,SectionName")] Section section)
        {
            if (ModelState.IsValid)
            {
                section.IsActive = 'Y';
                section.CreatedBy = "Admin";
                section.CreatedDate = DateTime.Now;
                _context.SectionRepository.Add(section);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(section);
        }

        // GET: Sections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = _context.SectionRepository.Get(u=>u.SectionId==id);
            if (section == null)
            {
                return NotFound();
            }
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SectionId,SectionName")] Section section)
        {
            if (id != section.SectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    section.UpdatedBy = "Admin";
                    section.UpdatedDate = DateTime.Now;
                    _context.SectionRepository.Update(section);
                    _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionExists(section.SectionId))
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
            return View(section);
        }

        // GET: Sections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section =  _context.SectionRepository
                .Get(m => m.SectionId == id);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var section = _context.SectionRepository.Get(u=>u.SectionId==id);
            if (section != null)
            {
                _context.SectionRepository.Remove(section);
            }

            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool SectionExists(int id)
        {
            return _context.SectionRepository.Get(e => e.SectionId == id).SectionId>0;
        }
    }
}
