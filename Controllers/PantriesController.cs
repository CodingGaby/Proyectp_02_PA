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
    public class PantriesController : Controller
    {
        private readonly DataContext _context;

        public PantriesController(DataContext context)
        {
            _context = context;
        }

        // GET: Pantries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pantries.ToListAsync());
        }

        // GET: Pantries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pantry = await _context.Pantries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pantry == null)
            {
                return NotFound();
            }

            return View(pantry);
        }

        // GET: Pantries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pantries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Descripcion, Ingredients")] Pantry pantry)
        {
            _context.Add(pantry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Pantries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pantry = await _context.Pantries.FindAsync(id);
            if (pantry == null)
            {
                return NotFound();
            }
            return View(pantry);
        }

        // POST: Pantries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Descripcion")] Pantry pantry)
        {
            if (id != pantry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pantry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PantryExists(pantry.Id))
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
            return View(pantry);
        }

        // GET: Pantries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pantry = await _context.Pantries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pantry == null)
            {
                return NotFound();
            }

            return View(pantry);
        }

        // POST: Pantries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pantry = await _context.Pantries.FindAsync(id);
            if (pantry != null)
            {
                _context.Pantries.Remove(pantry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PantryExists(int id)
        {
            return _context.Pantries.Any(e => e.Id == id);
        }
    }
}
