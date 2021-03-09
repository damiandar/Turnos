using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectoresController : ControllerBase
    {
        private readonly TurneraDbContext _context;

        public SectoresController(TurneraDbContext context)
        {
            _context = context;
        }

        // GET: api/Sectores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sector>>> GetSectores()
        {
            return await _context.Sectores.ToListAsync();
        }

        // GET: api/Sectores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sector>> GetSector(int id)
        {
            var sector = await _context.Sectores.FindAsync(id);

            if (sector == null)
            {
                return NotFound();
            }

            return sector;
        }

        // PUT: api/Sectores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSector(int id, Sector sector)
        {
            if (id != sector.Id)
            {
                return BadRequest();
            }

            _context.Entry(sector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectorExists(id))
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

        // POST: api/Sectores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sector>> PostSector(Sector sector)
        {
            _context.Sectores.Add(sector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSector", new { id = sector.Id }, sector);
        }

        // DELETE: api/Sectores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSector(int id)
        {
            var sector = await _context.Sectores.FindAsync(id);
            if (sector == null)
            {
                return NotFound();
            }

            _context.Sectores.Remove(sector);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SectorExists(int id)
        {
            return _context.Sectores.Any(e => e.Id == id);
        }
    }
}
