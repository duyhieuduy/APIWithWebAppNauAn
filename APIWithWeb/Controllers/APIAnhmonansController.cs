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
    public class APIAnhmonansController : ControllerBase
    {
        private readonly AppNauAnContext _context;

        public APIAnhmonansController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: api/APIAnhmonans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anhmonan>>> GetAnhmonans()
        {
            return await _context.Anhmonans.ToListAsync();
        }

        // GET: api/APIAnhmonans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anhmonan>> GetAnhmonan(int id)
        {
            var anhmonan = await _context.Anhmonans.FindAsync(id);

            if (anhmonan == null)
            {
                return NotFound();
            }

            return anhmonan;
        }

        // PUT: api/APIAnhmonans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnhmonan(int id, Anhmonan anhmonan)
        {
            if (id != anhmonan.IdAma)
            {
                return BadRequest();
            }

            _context.Entry(anhmonan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnhmonanExists(id))
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

        // POST: api/APIAnhmonans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Anhmonan>> PostAnhmonan(Anhmonan anhmonan)
        {
            _context.Anhmonans.Add(anhmonan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnhmonan", new { id = anhmonan.IdAma }, anhmonan);
        }

        // DELETE: api/APIAnhmonans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnhmonan(int id)
        {
            var anhmonan = await _context.Anhmonans.FindAsync(id);
            if (anhmonan == null)
            {
                return NotFound();
            }

            _context.Anhmonans.Remove(anhmonan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnhmonanExists(int id)
        {
            return _context.Anhmonans.Any(e => e.IdAma == id);
        }
    }
}
