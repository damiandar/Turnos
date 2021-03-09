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
    public class EspecializacionesController : ControllerBase
    {
        private readonly TurneraDbContext _context;

        public EspecializacionesController(TurneraDbContext context)
        {
            _context = context;
        }

        // GET: api/Especializaciones
        [HttpGet]
        /*public async Task<ActionResult<IEnumerable<Specialization>>> GetSpecialization()
        {
            return await _context.Specialization.ToListAsync();
        }*/
        public List<Specialization> GetSpecializationData()
        {
            List<Specialization> data = new List<Specialization>
            {
                new Specialization(1, "generalmedicine", "General Medicine", "#F538B2"),
                new Specialization(2, "neurology", "Neurology", "#33C7E8"),
                new Specialization(3, "dermatology", "Dermatology", "#916DE4"),
                new Specialization(4, "orthopedics", "Orthopedics", "#388CF5"),
                new Specialization(5, "diabetology", "Diabetology", "#60F238"),
                new Specialization(6, "cardiology", "Cardiology", "#F29438")
            };

            return data;
        }

        // GET: api/Especializaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Specialization>> GetSpecialization(string id)
        {
            var specialization = await _context.Specialization.FindAsync(id);

            if (specialization == null)
            {
                return NotFound();
            }

            return specialization;
        }

        // PUT: api/Especializaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialization(string id, Specialization specialization)
        {
            if (id != specialization.Id)
            {
                return BadRequest();
            }

            _context.Entry(specialization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecializationExists(id))
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

        // POST: api/Especializaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Specialization>> PostSpecialization(Specialization specialization)
        {
            _context.Specialization.Add(specialization);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpecializationExists(specialization.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSpecialization", new { id = specialization.Id }, specialization);
        }

        // DELETE: api/Especializaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialization(string id)
        {
            var specialization = await _context.Specialization.FindAsync(id);
            if (specialization == null)
            {
                return NotFound();
            }

            _context.Specialization.Remove(specialization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpecializationExists(string id)
        {
            return _context.Specialization.Any(e => e.Id == id);
        }
    }
}
