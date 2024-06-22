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
    public class SubjectsController : Controller
    {
        private readonly EducationalInstituteContext _context;

        public SubjectsController(EducationalInstituteContext context)
        {
            _context = context;
        }

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
            var educationalInstituteContext = _context.Subject.Include(s => s.SClass).Include(s => s.Section);
            return View(await educationalInstituteContext.ToListAsync());
        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .Include(s => s.SClass)
                .Include(s => s.Section)
                .FirstOrDefaultAsync(m => m.subjectId == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            ViewData["ClassID"] = new SelectList(_context.SClass, "ClassId", "ClassName");
            ViewData["SectionId"] = new SelectList(_context.Section, "SectionId", "SectionName");
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("subjectId,subjectName,ClassID,SectionId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                subject.IsActive = 'Y';
                subject.CreatedBy = "Admin";
                subject.CreatedDate=DateTime.Now;
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassID"] = new SelectList(_context.SClass, "ClassId", "ClassName", subject.ClassID);
            ViewData["SectionId"] = new SelectList(_context.Section, "SectionId", "SectionName", subject.SectionId);
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            ViewData["ClassID"] = new SelectList(_context.SClass, "ClassId", "ClassName", subject.ClassID);
            ViewData["SectionId"] = new SelectList(_context.Section, "SectionId", "SectionName", subject.SectionId);
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("subjectId,subjectName,ClassID,SectionId")] Subject subject)
        {
            if (id != subject.subjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    subject.UpdatedBy = "Admin";
                    subject.UpdatedDate = DateTime.Now;
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.subjectId))
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
            ViewData["ClassID"] = new SelectList(_context.SClass, "ClassId", "ClassName", subject.ClassID);
            ViewData["SectionId"] = new SelectList(_context.Section, "SectionId", "SectionName", subject.SectionId);
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .Include(s => s.SClass)
                .Include(s => s.Section)
                .FirstOrDefaultAsync(m => m.subjectId == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _context.Subject.FindAsync(id);
            if (subject != null)
            {
                _context.Subject.Remove(subject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            return _context.Subject.Any(e => e.subjectId == id);
        }
    }
}
