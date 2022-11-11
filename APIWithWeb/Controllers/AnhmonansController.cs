using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APIWithWeb.Models;

namespace APIWithWeb.Controllers
{
    public class AnhmonansController : Controller
    {
        private readonly AppNauAnContext _context;

        public AnhmonansController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: Anhmonans
        public async Task<IActionResult> Index()
        {
            var appNauAnContext = _context.Anhmonans.Include(a => a.MamonNavigation);
            return View(await appNauAnContext.ToListAsync());
        }

        // GET: Anhmonans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Anhmonans == null)
            {
                return NotFound();
            }

            var anhmonan = await _context.Anhmonans
                .Include(a => a.MamonNavigation)
                .FirstOrDefaultAsync(m => m.IdAma == id);
            if (anhmonan == null)
            {
                return NotFound();
            }

            return View(anhmonan);
        }

        // GET: Anhmonans/Create
        public IActionResult Create()
        {
            ViewData["Mamon"] = new SelectList(_context.Mons, "Mamon", "Mamon");
            return View();
        }

        // POST: Anhmonans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Anhmon,Mamon,IdAma")] Anhmonan anhmonan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anhmonan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mamon"] = new SelectList(_context.Mons, "Mamon", "Mamon", anhmonan.Mamon);
            return View(anhmonan);
        }

        // GET: Anhmonans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Anhmonans == null)
            {
                return NotFound();
            }

            var anhmonan = await _context.Anhmonans.FindAsync(id);
            if (anhmonan == null)
            {
                return NotFound();
            }
            ViewData["Mamon"] = new SelectList(_context.Mons, "Mamon", "Mamon", anhmonan.Mamon);
            return View(anhmonan);
        }

        // POST: Anhmonans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Anhmon,Mamon,IdAma")] Anhmonan anhmonan)
        {
            if (id != anhmonan.IdAma)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anhmonan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnhmonanExists(anhmonan.IdAma))
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
            ViewData["Mamon"] = new SelectList(_context.Mons, "Mamon", "Mamon", anhmonan.Mamon);
            return View(anhmonan);
        }

        // GET: Anhmonans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Anhmonans == null)
            {
                return NotFound();
            }

            var anhmonan = await _context.Anhmonans
                .Include(a => a.MamonNavigation)
                .FirstOrDefaultAsync(m => m.IdAma == id);
            if (anhmonan == null)
            {
                return NotFound();
            }

            return View(anhmonan);
        }

        // POST: Anhmonans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Anhmonans == null)
            {
                return Problem("Entity set 'AppNauAnContext.Anhmonans'  is null.");
            }
            var anhmonan = await _context.Anhmonans.FindAsync(id);
            if (anhmonan != null)
            {
                _context.Anhmonans.Remove(anhmonan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnhmonanExists(int id)
        {
          return _context.Anhmonans.Any(e => e.IdAma == id);
        }
    }
}
