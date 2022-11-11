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
    public class NguyenlieuxController : Controller
    {
        private readonly AppNauAnContext _context;

        public NguyenlieuxController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: Nguyenlieux
        public async Task<IActionResult> Index()
        {
              return View(await _context.Nguyenlieus.ToListAsync());
        }

        // GET: Nguyenlieux/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nguyenlieus == null)
            {
                return NotFound();
            }

            var nguyenlieu = await _context.Nguyenlieus
                .FirstOrDefaultAsync(m => m.Manguyenlieu == id);
            if (nguyenlieu == null)
            {
                return NotFound();
            }

            return View(nguyenlieu);
        }

        // GET: Nguyenlieux/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nguyenlieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Manguyenlieu,Tennguyenlieu,Anhnguyenlieu")] Nguyenlieu nguyenlieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguyenlieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nguyenlieu);
        }

        // GET: Nguyenlieux/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nguyenlieus == null)
            {
                return NotFound();
            }

            var nguyenlieu = await _context.Nguyenlieus.FindAsync(id);
            if (nguyenlieu == null)
            {
                return NotFound();
            }
            return View(nguyenlieu);
        }

        // POST: Nguyenlieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Manguyenlieu,Tennguyenlieu,Anhnguyenlieu")] Nguyenlieu nguyenlieu)
        {
            if (id != nguyenlieu.Manguyenlieu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguyenlieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguyenlieuExists(nguyenlieu.Manguyenlieu))
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
            return View(nguyenlieu);
        }

        // GET: Nguyenlieux/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nguyenlieus == null)
            {
                return NotFound();
            }

            var nguyenlieu = await _context.Nguyenlieus
                .FirstOrDefaultAsync(m => m.Manguyenlieu == id);
            if (nguyenlieu == null)
            {
                return NotFound();
            }

            return View(nguyenlieu);
        }

        // POST: Nguyenlieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nguyenlieus == null)
            {
                return Problem("Entity set 'AppNauAnContext.Nguyenlieus'  is null.");
            }
            var nguyenlieu = await _context.Nguyenlieus.FindAsync(id);
            if (nguyenlieu != null)
            {
                _context.Nguyenlieus.Remove(nguyenlieu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguyenlieuExists(string id)
        {
          return _context.Nguyenlieus.Any(e => e.Manguyenlieu == id);
        }
    }
}
