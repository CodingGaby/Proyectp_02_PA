using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyectp_02_PA.Data;
using Proyectp_02_PA.Data.Entities;

namespace Proyectp_02_PA.Controllers
{
    public class DiseaseDetailsController : Controller
    {
        private readonly DataContext _context;

        public DiseaseDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: DiseaseDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiseaseDetails.ToListAsync());
        }

        // GET: DiseaseDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseaseDetail = await _context.DiseaseDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diseaseDetail == null)
            {
                return NotFound();
            }

            return View(diseaseDetail);
        }

        // GET: DiseaseDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiseaseDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] DiseaseDetail diseaseDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diseaseDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diseaseDetail);
        }

        // GET: DiseaseDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseaseDetail = await _context.DiseaseDetails.FindAsync(id);
            if (diseaseDetail == null)
            {
                return NotFound();
            }
            return View(diseaseDetail);
        }

        // POST: DiseaseDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] DiseaseDetail diseaseDetail)
        {
            if (id != diseaseDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diseaseDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiseaseDetailExists(diseaseDetail.Id))
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
            return View(diseaseDetail);
        }

        // GET: DiseaseDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseaseDetail = await _context.DiseaseDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diseaseDetail == null)
            {
                return NotFound();
            }

            return View(diseaseDetail);
        }

        // POST: DiseaseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diseaseDetail = await _context.DiseaseDetails.FindAsync(id);
            if (diseaseDetail != null)
            {
                _context.DiseaseDetails.Remove(diseaseDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiseaseDetailExists(int id)
        {
            return _context.DiseaseDetails.Any(e => e.Id == id);
        }
    }
}
