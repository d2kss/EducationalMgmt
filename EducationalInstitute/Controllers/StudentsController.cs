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
    public class StudentsController : Controller
    {
        private readonly IUnitOfWork _context;

        public StudentsController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var educationalInstituteContext = _context.StudentRepository.Include(s => s.SClass).Include(s => s.Section).Include(s => s.Teacher);
            return View(await educationalInstituteContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.StudentRepository
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
            ViewData["ClassID"] = new SelectList(_context.ClassRepository.GetAll(), "ClassId", "ClassName");
            ViewData["SectionId"] = new SelectList(_context.SectionRepository.GetAll(), "SectionId", "SectionName");
            ViewData["TeacherId"] = new SelectList(_context.TeacherRepository.GetAll(), "TeacherId", "Designation");
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
                _context.StudentRepository.Add(student);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassID"] = new SelectList(_context.ClassRepository.GetAll(), "ClassId", "ClassName", student.ClassID);
            ViewData["SectionId"] = new SelectList(_context.SectionRepository.GetAll(), "SectionId", "SectionName", student.SectionId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherRepository.GetAll(), "TeacherId", "Designation", student.TeacherId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.StudentRepository.Get(u=>u.StudentId==id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["ClassID"] = new SelectList(_context.ClassRepository.GetAll(), "ClassId", "ClassName", student.ClassID);
            ViewData["SectionId"] = new SelectList(_context.SectionRepository.GetAll(), "SectionId", "SectionName", student.SectionId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherRepository.GetAll(), "TeacherId", "Designation", student.TeacherId);
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
                    _context.StudentRepository.Update(student);
                    _context.Save();
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
            ViewData["ClassID"] = new SelectList(_context.ClassRepository.GetAll(), "ClassId", "ClassName", student.ClassID);
            ViewData["SectionId"] = new SelectList(_context.SectionRepository.GetAll(), "SectionId", "SectionName", student.SectionId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherRepository.GetAll(), "TeacherId", "Designation", student.TeacherId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.StudentRepository
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
            var student =  _context.StudentRepository.Get(u=>u.TeacherId==id);
            if (student != null)
            {
                _context.StudentRepository.Remove(student);
            }

            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.StudentRepository.Get(e => e.StudentId == id).StudentId>0;
        }
    }
}
