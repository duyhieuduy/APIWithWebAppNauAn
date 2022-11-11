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
    public class APINguyenlieuController : ControllerBase
    {
        private readonly AppNauAnContext _context;

        public APINguyenlieuController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: api/APINguyenlieu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nguyenlieu>>> GetNguyenlieus()
        {
            return await _context.Nguyenlieus.ToListAsync();
        }

        // GET: api/APINguyenlieu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nguyenlieu>> GetNguyenlieu(string id)
        {
            var nguyenlieu = await _context.Nguyenlieus.FindAsync(id);

            if (nguyenlieu == null)
            {
                return NotFound();
            }

            return nguyenlieu;
        }

        // PUT: api/APINguyenlieu/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNguyenlieu(string id, Nguyenlieu nguyenlieu)
        {
            if (id != nguyenlieu.Manguyenlieu)
            {
                return BadRequest();
            }

            _context.Entry(nguyenlieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguyenlieuExists(id))
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

        // POST: api/APINguyenlieu
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nguyenlieu>> PostNguyenlieu(Nguyenlieu nguyenlieu)
        {
            _context.Nguyenlieus.Add(nguyenlieu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NguyenlieuExists(nguyenlieu.Manguyenlieu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNguyenlieu", new { id = nguyenlieu.Manguyenlieu }, nguyenlieu);
        }

        // DELETE: api/APINguyenlieu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNguyenlieu(string id)
        {
            var nguyenlieu = await _context.Nguyenlieus.FindAsync(id);
            if (nguyenlieu == null)
            {
                return NotFound();
            }

            _context.Nguyenlieus.Remove(nguyenlieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NguyenlieuExists(string id)
        {
            return _context.Nguyenlieus.Any(e => e.Manguyenlieu == id);
        }
    }
}
