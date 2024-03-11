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
    public class RecipeDetailsController : Controller
    {
        private readonly DataContext _context;

        public RecipeDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: RecipeDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecipeDetails.ToListAsync());
        }

        // GET: RecipeDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeDetail = await _context.RecipeDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipeDetail == null)
            {
                return NotFound();
            }

            return View(recipeDetail);
        }

        // GET: RecipeDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecipeDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] RecipeDetail recipeDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipeDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipeDetail);
        }

        // GET: RecipeDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeDetail = await _context.RecipeDetails.FindAsync(id);
            if (recipeDetail == null)
            {
                return NotFound();
            }
            return View(recipeDetail);
        }

        // POST: RecipeDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] RecipeDetail recipeDetail)
        {
            if (id != recipeDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeDetailExists(recipeDetail.Id))
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
            return View(recipeDetail);
        }

        // GET: RecipeDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeDetail = await _context.RecipeDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipeDetail == null)
            {
                return NotFound();
            }

            return View(recipeDetail);
        }

        // POST: RecipeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipeDetail = await _context.RecipeDetails.FindAsync(id);
            if (recipeDetail != null)
            {
                _context.RecipeDetails.Remove(recipeDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeDetailExists(int id)
        {
            return _context.RecipeDetails.Any(e => e.Id == id);
        }
    }
}
