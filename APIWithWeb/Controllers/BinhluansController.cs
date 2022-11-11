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
    public class BinhluansController : Controller
    {
        private readonly AppNauAnContext _context;

        public BinhluansController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: Binhluans
        public async Task<IActionResult> Index()
        {
            var appNauAnContext = _context.Binhluans.Include(b => b.MamonNavigation).Include(b => b.TendangnhapNavigation);
            return View(await appNauAnContext.ToListAsync());
        }

        // GET: Binhluans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Binhluans == null)
            {
                return NotFound();
            }

            var binhluan = await _context.Binhluans
                .Include(b => b.MamonNavigation)
                .Include(b => b.TendangnhapNavigation)
                .FirstOrDefaultAsync(m => m.IdBl == id);
            if (binhluan == null)
            {
                return NotFound();
            }

            return View(binhluan);
        }

        // GET: Binhluans/Create
        public IActionResult Create()
        {
            ViewData["Mamon"] = new SelectList(_context.Mons, "Mamon", "Mamon");
            ViewData["Tendangnhap"] = new SelectList(_context.Nguoidungs, "Tendangnhap", "Tendangnhap");
            return View();
        }

        // POST: Binhluans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tendangnhap,Mamon,Noidungbl,IdBl")] Binhluan binhluan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(binhluan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mamon"] = new SelectList(_context.Mons, "Mamon", "Mamon", binhluan.Mamon);
            ViewData["Tendangnhap"] = new SelectList(_context.Nguoidungs, "Tendangnhap", "Tendangnhap", binhluan.Tendangnhap);
            return View(binhluan);
        }

        // GET: Binhluans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Binhluans == null)
            {
                return NotFound();
            }

            var binhluan = await _context.Binhluans.FindAsync(id);
            if (binhluan == null)
            {
                return NotFound();
            }
            ViewData["Mamon"] = new SelectList(_context.Mons, "Mamon", "Mamon", binhluan.Mamon);
            ViewData["Tendangnhap"] = new SelectList(_context.Nguoidungs, "Tendangnhap", "Tendangnhap", binhluan.Tendangnhap);
            return View(binhluan);
        }

        // POST: Binhluans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tendangnhap,Mamon,Noidungbl,IdBl")] Binhluan binhluan)
        {
            if (id != binhluan.IdBl)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(binhluan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinhluanExists(binhluan.IdBl))
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
            ViewData["Mamon"] = new SelectList(_context.Mons, "Mamon", "Mamon", binhluan.Mamon);
            ViewData["Tendangnhap"] = new SelectList(_context.Nguoidungs, "Tendangnhap", "Tendangnhap", binhluan.Tendangnhap);
            return View(binhluan);
        }

        // GET: Binhluans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Binhluans == null)
            {
                return NotFound();
            }

            var binhluan = await _context.Binhluans
                .Include(b => b.MamonNavigation)
                .Include(b => b.TendangnhapNavigation)
                .FirstOrDefaultAsync(m => m.IdBl == id);
            if (binhluan == null)
            {
                return NotFound();
            }

            return View(binhluan);
        }

        // POST: Binhluans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Binhluans == null)
            {
                return Problem("Entity set 'AppNauAnContext.Binhluans'  is null.");
            }
            var binhluan = await _context.Binhluans.FindAsync(id);
            if (binhluan != null)
            {
                _context.Binhluans.Remove(binhluan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinhluanExists(int id)
        {
          return _context.Binhluans.Any(e => e.IdBl == id);
        }
    }
}
