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
    public class PacientesController : ControllerBase
    {
        private readonly TurneraDbContext _context;

        public PacientesController(TurneraDbContext context)
        {
            _context = context;
        }

        // GET: api/Pacientes
        [HttpGet]
        /*public async Task<ActionResult<IEnumerable<Patient>>> GetPatient()
        {
            return await _context.Patient.ToListAsync();
        }*/
        public List<Patient> GetPatientsData()
        {
            List<Patient> data = new List<Patient>
            {
                new Patient(1, "Laura", "Laura", new DateTime(1980, 8, 3), "(071) 555-4444", "laura90@mail.com", "507 - 20th Ave. E.\r\nApt. 2A", "Eye Checkup", "GENERAL", "O +ve", "Female", "Sweating, Chills and Shivering"),
                new Patient(2, "Milka", "Milka", new DateTime(2000, 3, 5), "(071) 555-4445", "milka40@sample.com", "908 W. Capital Way", "Bone Fracture", "ORTHOPEDICS", "AB +ve", "Female", "Swelling or bruising over a bone, Pain in the injured area"),
                new Patient(3, "Adams", "Adams", new DateTime(1985, 2, 3), "(071) 555-4454", "adams89@rpy.com", "722 Moss Bay Blvd.", "Eye and Spectactles", "GENERAL", "B +ve", "Male", "Frequent squinting, Eye fatigue or strain"),
                new Patient(4, "Janet", "Janet", new DateTime(2000, 7, 3), "(071) 555-4544", "janet79@rpy.com", "4110 Old Redmond Rd.", "Biological Problem", "GENERAL", "B +ve", "Male", "Physical aches or pain, Memory difficulties or personality change"),
                new Patient(5, "Mercy", "Mercy", new DateTime(2005, 4, 29), "(071) 555-5444", "mercy60@sample.com", "14 Garrett Hill", "Skin Hives", "DERMATOLOGY", "AB  -ve", "Female", "outbreak of swollen, pale red bumps or plaques"),
                new Patient(6, "Richa", "Richa", new DateTime(1989, 10, 29), "(206) 555-4444", "richa46@mail.com", "Coventry House\r\nMiner Rd.", "Arm Fracture", "ORTHOPEDICS", "B +ve", "Female", "Swelling, warmth, or redness in the joint"),
                new Patient(7, "Maud Oliver", "Maud Oliver", new DateTime(1989, 10, 29), "(206) 666-4444", "moud46@rpy.com", "Coventry House\r\nMiner Rd.", "Racing heartbeat", "CARDIOLOGY", "B +ve", "Male", "A fluttering in your chest")
            };
            return data;
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _context.Patient.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // PUT: api/Pacientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
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

        // POST: api/Pacientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            _context.Patient.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patient.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientExists(int id)
        {
            return _context.Patient.Any(e => e.Id == id);
        }
    }
}
