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
    public class APICongthucnguyenlieuController : ControllerBase
    {
        private readonly AppNauAnContext _context;

        public APICongthucnguyenlieuController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: api/APICongthucnguyenlieu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Congthucnguyenlieu>>> GetCongthucnguyenlieus()
        {
            return await _context.Congthucnguyenlieus.ToListAsync();
        }

        // GET: api/APICongthucnguyenlieu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Congthucnguyenlieu>> GetCongthucnguyenlieu(int id)
        {
            var congthucnguyenlieu = await _context.Congthucnguyenlieus.FindAsync(id);

            if (congthucnguyenlieu == null)
            {
                return NotFound();
            }

            return congthucnguyenlieu;
        }

        // PUT: api/APICongthucnguyenlieu/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCongthucnguyenlieu(int id, Congthucnguyenlieu congthucnguyenlieu)
        {
            if (id != congthucnguyenlieu.Ctnlid)
            {
                return BadRequest();
            }

            _context.Entry(congthucnguyenlieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CongthucnguyenlieuExists(id))
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

        // POST: api/APICongthucnguyenlieu
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Congthucnguyenlieu>> PostCongthucnguyenlieu(Congthucnguyenlieu congthucnguyenlieu)
        {
            _context.Congthucnguyenlieus.Add(congthucnguyenlieu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCongthucnguyenlieu", new { id = congthucnguyenlieu.Ctnlid }, congthucnguyenlieu);
        }

        // DELETE: api/APICongthucnguyenlieu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCongthucnguyenlieu(int id)
        {
            var congthucnguyenlieu = await _context.Congthucnguyenlieus.FindAsync(id);
            if (congthucnguyenlieu == null)
            {
                return NotFound();
            }

            _context.Congthucnguyenlieus.Remove(congthucnguyenlieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CongthucnguyenlieuExists(int id)
        {
            return _context.Congthucnguyenlieus.Any(e => e.Ctnlid == id);
        }
    }
}
