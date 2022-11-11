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
    public class APIBinhluansController : ControllerBase
    {
        private readonly AppNauAnContext _context;

        public APIBinhluansController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: api/APIBinhluans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Binhluan>>> GetBinhluans()
        {
            return await _context.Binhluans.ToListAsync();
        }

        // GET: api/APIBinhluans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Binhluan>> GetBinhluan(int id)
        {
            var binhluan = await _context.Binhluans.FindAsync(id);

            if (binhluan == null)
            {
                return NotFound();
            }

            return binhluan;
        }

        // PUT: api/APIBinhluans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBinhluan(int id, Binhluan binhluan)
        {
            if (id != binhluan.IdBl)
            {
                return BadRequest();
            }

            _context.Entry(binhluan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BinhluanExists(id))
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

        // POST: api/APIBinhluans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Binhluan>> PostBinhluan(Binhluan binhluan)
        {
            _context.Binhluans.Add(binhluan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBinhluan", new { id = binhluan.IdBl }, binhluan);
        }

        // DELETE: api/APIBinhluans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBinhluan(int id)
        {
            var binhluan = await _context.Binhluans.FindAsync(id);
            if (binhluan == null)
            {
                return NotFound();
            }

            _context.Binhluans.Remove(binhluan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BinhluanExists(int id)
        {
            return _context.Binhluans.Any(e => e.IdBl == id);
        }
    }
}
