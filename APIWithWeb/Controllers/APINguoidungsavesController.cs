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
    public class APINguoidungsavesController : ControllerBase
    {
        private readonly AppNauAnContext _context;

        public APINguoidungsavesController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: api/APINguoidungsaves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nguoidungsave>>> GetNguoidungsaves()
        {
            return await _context.Nguoidungsaves.ToListAsync();
        }

        // GET: api/APINguoidungsaves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nguoidungsave>> GetNguoidungsave(int id)
        {
            var nguoidungsave = await _context.Nguoidungsaves.FindAsync(id);

            if (nguoidungsave == null)
            {
                return NotFound();
            }

            return nguoidungsave;
        }

        // PUT: api/APINguoidungsaves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNguoidungsave(int id, Nguoidungsave nguoidungsave)
        {
            if (id != nguoidungsave.IdNds)
            {
                return BadRequest();
            }

            _context.Entry(nguoidungsave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoidungsaveExists(id))
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

        // POST: api/APINguoidungsaves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nguoidungsave>> PostNguoidungsave(Nguoidungsave nguoidungsave)
        {
            _context.Nguoidungsaves.Add(nguoidungsave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNguoidungsave", new { id = nguoidungsave.IdNds }, nguoidungsave);
        }

        // DELETE: api/APINguoidungsaves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNguoidungsave(int id)
        {
            var nguoidungsave = await _context.Nguoidungsaves.FindAsync(id);
            if (nguoidungsave == null)
            {
                return NotFound();
            }

            _context.Nguoidungsaves.Remove(nguoidungsave);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NguoidungsaveExists(int id)
        {
            return _context.Nguoidungsaves.Any(e => e.IdNds == id);
        }
    }
}
