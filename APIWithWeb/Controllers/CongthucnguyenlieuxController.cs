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
    public class CongthucnguyenlieuxController : Controller
    {
        private readonly AppNauAnContext _context;

        public CongthucnguyenlieuxController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: Congthucnguyenlieux
        public async Task<IActionResult> Index()
        {
            var appNauAnContext = _context.Congthucnguyenlieus.Include(c => c.MamonNavigation).Include(c => c.ManguyenlieuNavigation);
            return View(await appNauAnContext.ToListAsync());
        }

        // GET: Congthucnguyenlieux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Congthucnguyenlieus == null)
            {
                return NotFound();
            }

            var congthucnguyenlieu = await _context.Congthucnguyenlieus
                .Include(c => c.MamonNavigation)
                .Include(c => c.ManguyenlieuNavigation)
                .FirstOrDefaultAsync(m => m.Ctnlid == id);
            if (congthucnguyenlieu == null)
            {
                return NotFound();
            }

            return View(congthucnguyenlieu);
        }

        // GET: Congthucnguyenlieux/Create
        public IActionResult Create()
        {
            ViewData["Mamon"] = new SelectList(_context.Mons, "Mamon", "Mamon");
            ViewData["Manguyenlieu"] = new SelectList(_context.Nguyenlieus, "Manguyenlieu", "Manguyenlieu");
            return View();
        }

        // POST: Congthucnguyenlieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ctnlid,Mamon,Manguyenlieu,Khoiluong")] Congthucnguyenlieu congthucnguyenlieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(congthucnguyenlieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mamon"] = new SelectList(_context.Mons, "Mamon", "Mamon", congthucnguyenlieu.Mamon);
            ViewData["Manguyenlieu"] = new SelectList(_context.Nguyenlieus, "Manguyenlieu", "Manguyenlieu", congthucnguyenlieu.Manguyenlieu);
            return View(congthucnguyenlieu);
        }

        // GET: Congthucnguyenlieux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Congthucnguyenlieus == null)
            {
                return NotFound();
            }

            var congthucnguyenlieu = await _context.Congthucnguyenlieus.FindAsync(id);
            if (congthucnguyenlieu == null)
            {
                return NotFound();
            }
            ViewData["Mamon"] = new SelectList(_context.Mons, "Mamon", "Mamon", congthucnguyenlieu.Mamon);
            ViewData["Manguyenlieu"] = new SelectList(_context.Nguyenlieus, "Manguyenlieu", "Manguyenlieu", congthucnguyenlieu.Manguyenlieu);
            return View(congthucnguyenlieu);
        }

        // POST: Congthucnguyenlieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ctnlid,Mamon,Manguyenlieu,Khoiluong")] Congthucnguyenlieu congthucnguyenlieu)
        {
            if (id != congthucnguyenlieu.Ctnlid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(congthucnguyenlieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CongthucnguyenlieuExists(congthucnguyenlieu.Ctnlid))
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
            ViewData["Mamon"] = new SelectList(_context.Mons, "Mamon", "Mamon", congthucnguyenlieu.Mamon);
            ViewData["Manguyenlieu"] = new SelectList(_context.Nguyenlieus, "Manguyenlieu", "Manguyenlieu", congthucnguyenlieu.Manguyenlieu);
            return View(congthucnguyenlieu);
        }

        // GET: Congthucnguyenlieux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Congthucnguyenlieus == null)
            {
                return NotFound();
            }

            var congthucnguyenlieu = await _context.Congthucnguyenlieus
                .Include(c => c.MamonNavigation)
                .Include(c => c.ManguyenlieuNavigation)
                .FirstOrDefaultAsync(m => m.Ctnlid == id);
            if (congthucnguyenlieu == null)
            {
                return NotFound();
            }

            return View(congthucnguyenlieu);
        }

        // POST: Congthucnguyenlieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Congthucnguyenlieus == null)
            {
                return Problem("Entity set 'AppNauAnContext.Congthucnguyenlieus'  is null.");
            }
            var congthucnguyenlieu = await _context.Congthucnguyenlieus.FindAsync(id);
            if (congthucnguyenlieu != null)
            {
                _context.Congthucnguyenlieus.Remove(congthucnguyenlieu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CongthucnguyenlieuExists(int id)
        {
          return _context.Congthucnguyenlieus.Any(e => e.Ctnlid == id);
        }
    }
}
