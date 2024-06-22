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
    public class SClassesController : Controller
    {
        private readonly IUnitOfWork _context;

        public SClassesController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: SClasses
        public async Task<IActionResult> Index()
        {
            List<SClass> lstClasses = _context.ClassRepository.GetAll().ToList();
            return View(lstClasses);
        }

        // GET: SClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sClass =  _context.ClassRepository
                .Get(m => m.ClassId == id);
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
                _context.ClassRepository.Add(sClass);
                 _context.Save();
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

            var sClass = _context.ClassRepository.Get(u=>u.ClassId==id);
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
                    _context.ClassRepository.Update(sClass);
                    _context.Save();
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

            var sClass =  _context.ClassRepository
                .Get(m => m.ClassId == id);
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
            var sClass = _context.ClassRepository.Get(u => u.ClassId == id);
            if (sClass != null)
            {
                _context.ClassRepository.Remove(sClass);
            }

            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool SClassExists(int id)
        {
            return _context.ClassRepository.Get(e => e.ClassId == id).ClassId>0;
        }
    }
}
