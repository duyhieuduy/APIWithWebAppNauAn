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
    public class MonsController : Controller
    {
        private readonly AppNauAnContext _context;

        public MonsController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: Mons
        public async Task<IActionResult> Index()
        {
            var appNauAnContext = _context.Mons.Include(m => m.MaloaiNavigation);
            return View(await appNauAnContext.ToListAsync());
        }

        // GET: Mons/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Mons == null)
            {
                return NotFound();
            }

            var mon = await _context.Mons
                .Include(m => m.MaloaiNavigation)
                .FirstOrDefaultAsync(m => m.Mamon == id);
            if (mon == null)
            {
                return NotFound();
            }

            return View(mon);
        }

        // GET: Mons/Create
        public IActionResult Create()
        {
            ViewData["Maloai"] = new SelectList(_context.Loaimons, "Maloai", "Maloai");
            return View();
        }

        // POST: Mons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mamon,Tenmon,Maloai,Congthuclam")] Mon mon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Maloai"] = new SelectList(_context.Loaimons, "Maloai", "Maloai", mon.Maloai);
            return View(mon);
        }

        // GET: Mons/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Mons == null)
            {
                return NotFound();
            }

            var mon = await _context.Mons.FindAsync(id);
            if (mon == null)
            {
                return NotFound();
            }
            ViewData["Maloai"] = new SelectList(_context.Loaimons, "Maloai", "Maloai", mon.Maloai);
            return View(mon);
        }

        // POST: Mons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Mamon,Tenmon,Maloai,Congthuclam")] Mon mon)
        {
            if (id != mon.Mamon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonExists(mon.Mamon))
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
            ViewData["Maloai"] = new SelectList(_context.Loaimons, "Maloai", "Maloai", mon.Maloai);
            return View(mon);
        }

        // GET: Mons/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Mons == null)
            {
                return NotFound();
            }

            var mon = await _context.Mons
                .Include(m => m.MaloaiNavigation)
                .FirstOrDefaultAsync(m => m.Mamon == id);
            if (mon == null)
            {
                return NotFound();
            }

            return View(mon);
        }

        // POST: Mons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Mons == null)
            {
                return Problem("Entity set 'AppNauAnContext.Mons'  is null.");
            }
            var mon = await _context.Mons.FindAsync(id);
            if (mon != null)
            {
                _context.Mons.Remove(mon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonExists(string id)
        {
          return _context.Mons.Any(e => e.Mamon == id);
        }
    }
}
