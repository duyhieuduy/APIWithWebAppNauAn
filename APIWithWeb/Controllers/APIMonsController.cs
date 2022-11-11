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
    public class APIMonsController : ControllerBase
    {
        private readonly AppNauAnContext _context;

        public APIMonsController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: api/APIMons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mon>>> GetMons()
        {
            return await _context.Mons.ToListAsync();
        }

        // GET: api/APIMons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mon>> GetMon(string id)
        {
            var mon = await _context.Mons.FindAsync(id);

            if (mon == null)
            {
                return NotFound();
            }

            return mon;
        }

        // PUT: api/APIMons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMon(string id, Mon mon)
        {
            if (id != mon.Mamon)
            {
                return BadRequest();
            }

            _context.Entry(mon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonExists(id))
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

        // POST: api/APIMons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mon>> PostMon(Mon mon)
        {
            _context.Mons.Add(mon);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MonExists(mon.Mamon))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMon", new { id = mon.Mamon }, mon);
        }

        // DELETE: api/APIMons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMon(string id)
        {
            var mon = await _context.Mons.FindAsync(id);
            if (mon == null)
            {
                return NotFound();
            }

            _context.Mons.Remove(mon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonExists(string id)
        {
            return _context.Mons.Any(e => e.Mamon == id);
        }
    }
}
