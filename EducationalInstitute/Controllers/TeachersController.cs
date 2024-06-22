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
    public class TeachersController : Controller
    {
        private readonly IUnitOfWork _context;

        public TeachersController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            return View(_context.TeacherRepository.GetAll().ToList());
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher =  _context.TeacherRepository
                .Get(m => m.TeacherId == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,FirstName,LastName,FatherName,MotherName,DOB,Qualification,SubjectExpert,Salary,Designation,IsActive,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.TeacherRepository.Add(teacher);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = _context.TeacherRepository.Get(u=>u.TeacherId==id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherId,FirstName,LastName,FatherName,MotherName,DOB,Qualification,SubjectExpert,Salary,Designation,IsActive,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate")] Teacher teacher)
        {
            if (id != teacher.TeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.TeacherRepository.Update(teacher);
                    _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.TeacherId))
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
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = _context.TeacherRepository
                .Get(m => m.TeacherId == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher =  _context.TeacherRepository.Get(u=>u.TeacherId==id);
            if (teacher != null)
            {
                _context.TeacherRepository.Remove(teacher);
            }

            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return _context.TeacherRepository.Get(e => e.TeacherId == id).TeacherId>0;
        }
    }
}
