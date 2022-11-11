using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIWithWeb.Models;

namespace APIWithWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APINguoidungsController : ControllerBase
    {
        private readonly AppNauAnContext _context;

        public APINguoidungsController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: api/APINguoidungs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nguoidung>>> GetNguoidungs()
        {
            return await _context.Nguoidungs.ToListAsync();
        }

        // GET: api/APINguoidungs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nguoidung>> GetNguoidung(string id)
        {
            var nguoidung = await _context.Nguoidungs.FindAsync(id);

            if (nguoidung == null)
            {
                return NotFound();
            }

            return nguoidung;
        }

        // PUT: api/APINguoidungs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNguoidung(string id, Nguoidung nguoidung)
        {
            if (id != nguoidung.Tendangnhap)
            {
                return BadRequest();
            }

            _context.Entry(nguoidung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoidungExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/APINguoidungs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nguoidung>> PostNguoidung(Nguoidung nguoidung)
        {
            _context.Nguoidungs.Add(nguoidung);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NguoidungExists(nguoidung.Tendangnhap))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNguoidung", new { id = nguoidung.Tendangnhap }, nguoidung);
        }

        // DELETE: api/APINguoidungs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNguoidung(string id)
        {
            var nguoidung = await _context.Nguoidungs.FindAsync(id);
            if (nguoidung == null)
            {
                return NotFound();
            }

            _context.Nguoidungs.Remove(nguoidung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NguoidungExists(string id)
        {
            return _context.Nguoidungs.Any(e => e.Tendangnhap == id);
        }
    }
}
