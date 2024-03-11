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
    public class DailyActivitiesController : Controller
    {
        private readonly DataContext _context;

        public DailyActivitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: DailyActivities
        public async Task<IActionResult> Index()
        {
            return View(await _context.DailyActivities.ToListAsync());
        }

        // GET: DailyActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyActivity = await _context.DailyActivities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dailyActivity == null)
            {
                return NotFound();
            }

            return View(dailyActivity);
        }

        // GET: DailyActivities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DailyActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Descripcion")] DailyActivity dailyActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dailyActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dailyActivity);
        }

        // GET: DailyActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyActivity = await _context.DailyActivities.FindAsync(id);
            if (dailyActivity == null)
            {
                return NotFound();
            }
            return View(dailyActivity);
        }

        // POST: DailyActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Descripcion")] DailyActivity dailyActivity)
        {
            if (id != dailyActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dailyActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyActivityExists(dailyActivity.Id))
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
            return View(dailyActivity);
        }

        // GET: DailyActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyActivity = await _context.DailyActivities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dailyActivity == null)
            {
                return NotFound();
            }

            return View(dailyActivity);
        }

        // POST: DailyActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dailyActivity = await _context.DailyActivities.FindAsync(id);
            if (dailyActivity != null)
            {
                _context.DailyActivities.Remove(dailyActivity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DailyActivityExists(int id)
        {
            return _context.DailyActivities.Any(e => e.Id == id);
        }
    }
}
