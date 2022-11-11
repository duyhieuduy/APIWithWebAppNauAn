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
    public class LoaimonsController : Controller
    {
        private readonly AppNauAnContext _context;

        public LoaimonsController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: Loaimons
        public async Task<IActionResult> Index()
        {
              return View(await _context.Loaimons.ToListAsync());
        }

        // GET: Loaimons/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Loaimons == null)
            {
                return NotFound();
            }

            var loaimon = await _context.Loaimons
                .FirstOrDefaultAsync(m => m.Maloai == id);
            if (loaimon == null)
            {
                return NotFound();
            }

            return View(loaimon);
        }

        // GET: Loaimons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loaimons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Maloai,Tenloai")] Loaimon loaimon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaimon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaimon);
        }

        // GET: Loaimons/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Loaimons == null)
            {
                return NotFound();
            }

            var loaimon = await _context.Loaimons.FindAsync(id);
            if (loaimon == null)
            {
                return NotFound();
            }
            return View(loaimon);
        }

        // POST: Loaimons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Maloai,Tenloai")] Loaimon loaimon)
        {
            if (id != loaimon.Maloai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaimon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaimonExists(loaimon.Maloai))
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
            return View(loaimon);
        }

        // GET: Loaimons/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Loaimons == null)
            {
                return NotFound();
            }

            var loaimon = await _context.Loaimons
                .FirstOrDefaultAsync(m => m.Maloai == id);
            if (loaimon == null)
            {
                return NotFound();
            }

            return View(loaimon);
        }

        // POST: Loaimons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Loaimons == null)
            {
                return Problem("Entity set 'AppNauAnContext.Loaimons'  is null.");
            }
            var loaimon = await _context.Loaimons.FindAsync(id);
            if (loaimon != null)
            {
                _context.Loaimons.Remove(loaimon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaimonExists(string id)
        {
          return _context.Loaimons.Any(e => e.Maloai == id);
        }
    }
}
