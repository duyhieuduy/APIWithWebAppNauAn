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
    public class NguoidungsavesController : Controller
    {
        private readonly AppNauAnContext _context;

        public NguoidungsavesController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: Nguoidungsaves
        public async Task<IActionResult> Index()
        {
            var appNauAnContext = _context.Nguoidungsaves.Include(n => n.MamonNavigation).Include(n => n.TendangnhapNavigation);
            return View(await appNauAnContext.ToListAsync());
        }

        // GET: Nguoidungsaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nguoidungsaves == null)
            {
                return NotFound();
            }

            var nguoidungsave = await _context.Nguoidungsaves
                .Include(n => n.MamonNavigation)
                .Include(n => n.TendangnhapNavigation)
                .FirstOrDefaultAsync(m => m.IdNds == id);
            if (nguoidungsave == null)
            {
                return NotFound();
            }

            return View(nguoidungsave);
        }

        // GET: Nguoidungsaves/Create
        public IActionResult Create()
        {
            ViewData["Mamon"] = new SelectList(_context.Mons, "Mamon", "Mamon");
            ViewData["Tendangnhap"] = new SelectList(_context.Nguoidungs, "Tendangnhap", "Tendangnhap");
            return View();
        }

        // POST: Nguoidungsaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tendangnhap,Mamon,IdNds")] Nguoidungsave nguoidungsave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoidungsave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mamon"] = new SelectList(_context.Mons, "Mamon", "Mamon", nguoidungsave.Mamon);
            ViewData["Tendangnhap"] = new SelectList(_context.Nguoidungs, "Tendangnhap", "Tendangnhap", nguoidungsave.Tendangnhap);
            return View(nguoidungsave);
        }

        // GET: Nguoidungsaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nguoidungsaves == null)
            {
                return NotFound();
            }

            var nguoidungsave = await _context.Nguoidungsaves.FindAsync(id);
            if (nguoidungsave == null)
            {
                return NotFound();
            }
            ViewData["Mamon"] = new SelectList(_context.Mons, "Mamon", "Mamon", nguoidungsave.Mamon);
            ViewData["Tendangnhap"] = new SelectList(_context.Nguoidungs, "Tendangnhap", "Tendangnhap", nguoidungsave.Tendangnhap);
            return View(nguoidungsave);
        }

        // POST: Nguoidungsaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tendangnhap,Mamon,IdNds")] Nguoidungsave nguoidungsave)
        {
            if (id != nguoidungsave.IdNds)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoidungsave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoidungsaveExists(nguoidungsave.IdNds))
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
            ViewData["Mamon"] = new SelectList(_context.Mons, "Mamon", "Mamon", nguoidungsave.Mamon);
            ViewData["Tendangnhap"] = new SelectList(_context.Nguoidungs, "Tendangnhap", "Tendangnhap", nguoidungsave.Tendangnhap);
            return View(nguoidungsave);
        }

        // GET: Nguoidungsaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nguoidungsaves == null)
            {
                return NotFound();
            }

            var nguoidungsave = await _context.Nguoidungsaves
                .Include(n => n.MamonNavigation)
                .Include(n => n.TendangnhapNavigation)
                .FirstOrDefaultAsync(m => m.IdNds == id);
            if (nguoidungsave == null)
            {
                return NotFound();
            }

            return View(nguoidungsave);
        }

        // POST: Nguoidungsaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nguoidungsaves == null)
            {
                return Problem("Entity set 'AppNauAnContext.Nguoidungsaves'  is null.");
            }
            var nguoidungsave = await _context.Nguoidungsaves.FindAsync(id);
            if (nguoidungsave != null)
            {
                _context.Nguoidungsaves.Remove(nguoidungsave);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguoidungsaveExists(int id)
        {
          return _context.Nguoidungsaves.Any(e => e.IdNds == id);
        }
    }
}
