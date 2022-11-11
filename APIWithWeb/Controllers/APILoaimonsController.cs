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
    public class APILoaimonsController : ControllerBase
    {
        private readonly AppNauAnContext _context;

        public APILoaimonsController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: api/APILoaimons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loaimon>>> GetLoaimons()
        {
            return await _context.Loaimons.ToListAsync();
        }

        // GET: api/APILoaimons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loaimon>> GetLoaimon(string id)
        {
            var loaimon = await _context.Loaimons.FindAsync(id);

            if (loaimon == null)
            {
                return NotFound();
            }

            return loaimon;
        }

        // PUT: api/APILoaimons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaimon(string id, Loaimon loaimon)
        {
            if (id != loaimon.Maloai)
            {
                return BadRequest();
            }

            _context.Entry(loaimon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaimonExists(id))
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

        // POST: api/APILoaimons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Loaimon>> PostLoaimon(Loaimon loaimon)
        {
            _context.Loaimons.Add(loaimon);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoaimonExists(loaimon.Maloai))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoaimon", new { id = loaimon.Maloai }, loaimon);
        }

        // DELETE: api/APILoaimons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaimon(string id)
        {
            var loaimon = await _context.Loaimons.FindAsync(id);
            if (loaimon == null)
            {
                return NotFound();
            }

            _context.Loaimons.Remove(loaimon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoaimonExists(string id)
        {
            return _context.Loaimons.Any(e => e.Maloai == id);
        }
    }
}
