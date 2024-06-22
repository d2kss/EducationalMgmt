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
    public class ExamsController : Controller
    {
        private readonly IUnitOfWork _context;

        public ExamsController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: Exams
        public async Task<IActionResult> Index()
        {
            List<Exam> lstExams = _context.ExamRepository.Include(e => e.SClass).Include(e => e.Section).ToList();
            return View(lstExams);
        }

        // GET: Exams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.ExamRepository
                .Include(e => e.SClass)
                .Include(e => e.Section)
                .FirstOrDefaultAsync(m => m.ExamId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // GET: Exams/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.ClassRepository.GetAll(), "ClassId", "ClassName");
            ViewData["SectionId"] = new SelectList(_context.SectionRepository.GetAll(), "SectionId", "SectionName");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExamId,ExamName,ClassId,SectionId,DateofExam,IsActive,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                _context.ExamRepository.Add(exam);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.ClassRepository.GetAll(), "ClassId", "ClassName", exam.ClassId);
            ViewData["SectionId"] = new SelectList(_context.SectionRepository.GetAll(), "SectionId", "SectionName", exam.SectionId);
            return View(exam);
        }

        // GET: Exams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = _context.ExamRepository.Get(u=>u.ExamId==id);
            if (exam == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.ClassRepository.GetAll(), "ClassId", "ClassName", exam.ClassId);
            ViewData["SectionId"] = new SelectList(_context.SectionRepository.GetAll(), "SectionId", "SectionName", exam.SectionId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExamId,ExamName,ClassId,SectionId,DateofExam,IsActive,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate")] Exam exam)
        {
            if (id != exam.ExamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.ExamRepository.Update(exam);
                    _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamExists(exam.ExamId))
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
            ViewData["ClassId"] = new SelectList(_context.ClassRepository.GetAll(), "ClassId", "ClassName", exam.ClassId);
            ViewData["SectionId"] = new SelectList(_context.SectionRepository.GetAll(), "SectionId", "SectionName", exam.SectionId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.ExamRepository
                .Include(e => e.SClass)
                .Include(e => e.Section)
                .FirstOrDefaultAsync(m => m.ExamId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exam = _context.ExamRepository.Get(u => u.ExamId == id);
            if (exam != null)
            {
                _context.ExamRepository.Remove(exam);
            }

            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamExists(int id)
        {
            return _context.ExamRepository.Get(e => e.ExamId == id).ExamId>0;
        }
    }
}
