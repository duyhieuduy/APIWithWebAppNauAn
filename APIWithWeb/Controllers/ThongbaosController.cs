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
    public class ThongbaosController : Controller
    {
        private readonly AppNauAnContext _context;

        public ThongbaosController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: Thongbaos
        public async Task<IActionResult> Index()
        {
            var appNauAnContext = _context.Thongbaos.Include(t => t.TendangnhapNavigation);
            return View(await appNauAnContext.ToListAsync());
        }

        // GET: Thongbaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Thongbaos == null)
            {
                return NotFound();
            }

            var thongbao = await _context.Thongbaos
                .Include(t => t.TendangnhapNavigation)
                .FirstOrDefaultAsync(m => m.IdTb == id);
            if (thongbao == null)
            {
                return NotFound();
            }

            return View(thongbao);
        }

        // GET: Thongbaos/Create
        public IActionResult Create()
        {
            ViewData["Tendangnhap"] = new SelectList(_context.Nguoidungs, "Tendangnhap", "Tendangnhap");
            return View();
        }

        // POST: Thongbaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tendangnhap,Noidungtb,IdTb")] Thongbao thongbao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thongbao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tendangnhap"] = new SelectList(_context.Nguoidungs, "Tendangnhap", "Tendangnhap", thongbao.Tendangnhap);
            return View(thongbao);
        }

        // GET: Thongbaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Thongbaos == null)
            {
                return NotFound();
            }

            var thongbao = await _context.Thongbaos.FindAsync(id);
            if (thongbao == null)
            {
                return NotFound();
            }
            ViewData["Tendangnhap"] = new SelectList(_context.Nguoidungs, "Tendangnhap", "Tendangnhap", thongbao.Tendangnhap);
            return View(thongbao);
        }

        // POST: Thongbaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tendangnhap,Noidungtb,IdTb")] Thongbao thongbao)
        {
            if (id != thongbao.IdTb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thongbao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThongbaoExists(thongbao.IdTb))
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
            ViewData["Tendangnhap"] = new SelectList(_context.Nguoidungs, "Tendangnhap", "Tendangnhap", thongbao.Tendangnhap);
            return View(thongbao);
        }

        // GET: Thongbaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Thongbaos == null)
            {
                return NotFound();
            }

            var thongbao = await _context.Thongbaos
                .Include(t => t.TendangnhapNavigation)
                .FirstOrDefaultAsync(m => m.IdTb == id);
            if (thongbao == null)
            {
                return NotFound();
            }

            return View(thongbao);
        }

        // POST: Thongbaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Thongbaos == null)
            {
                return Problem("Entity set 'AppNauAnContext.Thongbaos'  is null.");
            }
            var thongbao = await _context.Thongbaos.FindAsync(id);
            if (thongbao != null)
            {
                _context.Thongbaos.Remove(thongbao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThongbaoExists(int id)
        {
          return _context.Thongbaos.Any(e => e.IdTb == id);
        }
    }
}
