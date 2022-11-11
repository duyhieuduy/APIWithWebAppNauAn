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
    public class APIThongbaosController : ControllerBase
    {
        private readonly AppNauAnContext _context;

        public APIThongbaosController(AppNauAnContext context)
        {
            _context = context;
        }

        // GET: api/APIThongbaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thongbao>>> GetThongbaos()
        {
            return await _context.Thongbaos.ToListAsync();
        }

        // GET: api/APIThongbaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Thongbao>> GetThongbao(int id)
        {
            var thongbao = await _context.Thongbaos.FindAsync(id);

            if (thongbao == null)
            {
                return NotFound();
            }

            return thongbao;
        }

        // PUT: api/APIThongbaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThongbao(int id, Thongbao thongbao)
        {
            if (id != thongbao.IdTb)
            {
                return BadRequest();
            }

            _context.Entry(thongbao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThongbaoExists(id))
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

        // POST: api/APIThongbaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Thongbao>> PostThongbao(Thongbao thongbao)
        {
            _context.Thongbaos.Add(thongbao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThongbao", new { id = thongbao.IdTb }, thongbao);
        }

        // DELETE: api/APIThongbaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThongbao(int id)
        {
            var thongbao = await _context.Thongbaos.FindAsync(id);
            if (thongbao == null)
            {
                return NotFound();
            }

            _context.Thongbaos.Remove(thongbao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThongbaoExists(int id)
        {
            return _context.Thongbaos.Any(e => e.IdTb == id);
        }
    }
}
