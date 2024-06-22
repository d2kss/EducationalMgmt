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
    public class StudentsController : Controller
    {
        private readonly EducationalInstituteContext _context;

        public StudentsController(EducationalInstituteContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var educationalInstituteContext = _context.Student.Include(s => s.SClass).Include(s => s.Section).Include(s => s.Teacher);
            return View(await educationalInstituteContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.SClass)
                .Include(s => s.Section)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["ClassID"] = new SelectList(_context.SClass, "ClassId", "ClassName");
            ViewData["SectionId"] = new SelectList(_context.Section, "SectionId", "SectionName");
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "Designation");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,FirstName,LastName,FatherName,MotherName,Email,Phone,DOB,ClassID,SectionId,TotalFees,TeacherId,Address")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.IsActive = 'Y';
                student.CreatedBy = "Admin";
                student.CreatedDate= DateTime.Now;
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassID"] = new SelectList(_context.SClass, "ClassId", "ClassName", student.ClassID);
            ViewData["SectionId"] = new SelectList(_context.Section, "SectionId", "SectionName", student.SectionId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "Designation", student.TeacherId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["ClassID"] = new SelectList(_context.SClass, "ClassId", "ClassName", student.ClassID);
            ViewData["SectionId"] = new SelectList(_context.Section, "SectionId", "SectionName", student.SectionId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "Designation", student.TeacherId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,FirstName,LastName,FatherName,MotherName,Email,Phone,DOB,ClassID,SectionId,TotalFees,TeacherId,Address,IsActive,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            ViewData["ClassID"] = new SelectList(_context.SClass, "ClassId", "ClassName", student.ClassID);
            ViewData["SectionId"] = new SelectList(_context.Section, "SectionId", "SectionName", student.SectionId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "Designation", student.TeacherId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.SClass)
                .Include(s => s.Section)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student != null)
            {
                _context.Student.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StudentId == id);
        }
    }
}
