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
    public class DoctoresController : ControllerBase
    {
        private readonly TurneraDbContext _context;

        public DoctoresController(TurneraDbContext context)
        {
            _context = context;
        }

        // GET: api/Doctores
        [HttpGet]
        /*public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctor()
        {
            return await _context.Doctor.ToListAsync();
        }*/
        public List<Doctor> GetDoctorsData()
        {
            List<WorkDay> workDays = new List<WorkDay>
            {
                new WorkDay("Sunday", 0, true, new DateTime(2020, 2, 01, 08, 0, 0), new DateTime(2020, 2, 01, 17, 0, 0), new DateTime(2020, 2, 01, 12, 0, 0), new DateTime(2020, 2, 01, 13, 0, 0), "AddBreak"),
                new WorkDay("Monday", 1, false, new DateTime(2020, 2, 2, 8, 0, 0), new DateTime(2020, 2, 2, 17, 0, 0), new DateTime(2020, 2, 2, 12, 0, 0), new DateTime(2020, 2, 2, 13, 0, 0), "TimeOff"),
                new WorkDay("Tuesday", 2, true, new DateTime(2020, 2, 3, 8, 0, 0), new DateTime(2020, 2, 3, 17, 0, 0), new DateTime(2020, 2, 3, 12, 0, 0), new DateTime(2020, 2, 3, 13, 0, 0), "AddBreak"),
                new WorkDay("Wednesday", 3, true, new DateTime(2020, 2, 4, 8, 0, 0), new DateTime(2020, 2, 4, 17, 0, 0), new DateTime(2020, 2, 4, 12, 0, 0), new DateTime(2020, 2, 4, 13, 0, 0), "AddBreak"),
                new WorkDay("Thursday", 4, true, new DateTime(2020, 2, 5, 08, 0, 0), new DateTime(2020, 2, 5, 17, 0, 0), new DateTime(2020, 2, 5, 12, 0, 0), new DateTime(2020, 2, 5, 13, 0, 0), "AddBreak"),
                new WorkDay("Friday", 5, true, new DateTime(2020, 2, 6, 8, 0, 0), new DateTime(2020, 2, 6, 17, 0, 0), new DateTime(2020, 2, 6, 12, 0, 0), new DateTime(2020, 2, 6, 13, 0, 0), "RemoveBreak"),
                new WorkDay("Saturday", 6, false, new DateTime(2020, 2, 7, 8, 0, 0), new DateTime(2020, 2, 7, 17, 0, 0), new DateTime(2020, 2, 7, 12, 0, 0), new DateTime(2020, 2, 7, 13, 0, 0), "TimeOff")
            };

            List<WorkDay> workDays1 = new List<WorkDay>
            {
                new WorkDay("Sunday", 0, true, new DateTime(2020, 2, 01, 10, 0, 0), new DateTime(2020, 2, 01, 19, 0, 0), new DateTime(2020, 2, 01, 14, 0, 0), new DateTime(2020, 2, 01, 15, 0, 0), "AddBreak"),
                new WorkDay("Monday", 1, true, new DateTime(2020, 2, 2, 10, 0, 0), new DateTime(2020, 2, 2, 19, 0, 0), new DateTime(2020, 2, 2, 14, 0, 0), new DateTime(2020, 2, 2, 15, 0, 0), "RemoveBreak"),
                new WorkDay("Tuesday", 2, true, new DateTime(2020, 2, 3, 10, 0, 0), new DateTime(2020, 2, 3, 19, 0, 0), new DateTime(2020, 2, 3, 14, 0, 0), new DateTime(2020, 2, 3, 15, 0, 0), "AddBreak"),
                new WorkDay("Wednesday", 3, true, new DateTime(2020, 2, 4, 10, 0, 0), new DateTime(2020, 2, 4, 19, 0, 0), new DateTime(2020, 2, 4, 14, 0, 0), new DateTime(2020, 2, 4, 15, 0, 0), "AddBreak"),
                new WorkDay("Thursday", 4, true, new DateTime(2020, 2, 5, 10, 0, 0), new DateTime(2020, 2, 5, 19, 0, 0), new DateTime(2020, 2, 5, 14, 0, 0), new DateTime(2020, 2, 5, 15, 0, 0), "RemoveBreak"),
                new WorkDay("Friday", 5, false, new DateTime(2020, 2, 6, 10, 0, 0), new DateTime(2020, 2, 6, 19, 0, 0), new DateTime(2020, 2, 6, 14, 0, 0), new DateTime(2020, 2, 6, 15, 0, 0), "TimeOff"),
                new WorkDay("Saturday", 6, false, new DateTime(2020, 2, 7, 10, 0, 0), new DateTime(2020, 2, 7, 19, 0, 0), new DateTime(2020, 2, 7, 14, 0, 0), new DateTime(2020, 2, 7, 15, 0, 0), "TimeOff")
            };

            List<WorkDay> workDays2 = new List<WorkDay>
            {
                new WorkDay("Sunday", 0, false, new DateTime(2020, 2, 01, 12, 0, 0), new DateTime(2020, 2, 01, 21, 0, 0), new DateTime(2020, 2, 01, 16, 0, 0), new DateTime(2020, 2, 01, 17, 0, 0), "TimeOff"),
                new WorkDay("Monday", 1, true, new DateTime(2020, 2, 2, 12, 0, 0), new DateTime(2020, 2, 2, 21, 0, 0), new DateTime(2020, 2, 2, 16, 0, 0), new DateTime(2020, 2, 2, 17, 0, 0), "AddBreak"),
                new WorkDay("Tuesday", 2, true, new DateTime(2020, 2, 3, 12, 0, 0), new DateTime(2020, 2, 3, 21, 0, 0), new DateTime(2020, 2, 3, 16, 0, 0), new DateTime(2020, 2, 3, 17, 0, 0), "AddBreak"),
                new WorkDay("Wednesday", 3, true, new DateTime(2020, 2, 4, 12, 0, 0), new DateTime(2020, 2, 4, 21, 0, 0), new DateTime(2020, 2, 4, 16, 0, 0), new DateTime(2020, 2, 4, 17, 0, 0), "AddBreak"),
                new WorkDay("Thursday", 4, true, new DateTime(2020, 2, 5, 12, 0, 0), new DateTime(2020, 2, 5, 21, 0, 0), new DateTime(2020, 2, 5, 16, 0, 0), new DateTime(2020, 2, 5, 17, 0, 0), "AddBreak"),
                new WorkDay("Friday", 5, true, new DateTime(2020, 2, 6, 12, 0, 0), new DateTime(2020, 2, 6, 21, 0, 0), new DateTime(2020, 2, 6, 16, 0, 0), new DateTime(2020, 2, 6, 17, 0, 0), "RemoveBreak"),
                new WorkDay("Saturday", 6, false, new DateTime(2020, 2, 7, 12, 0, 0), new DateTime(2020, 2, 7, 21, 0, 0), new DateTime(2020, 2, 7, 16, 0, 0), new DateTime(2020, 2, 7, 17, 0, 0), "TimeOff")
            };

            List<WorkDay> workDays3 = new List<WorkDay>
            {
                new WorkDay("Sunday", 0, false, new DateTime(2020, 2, 01, 8, 0, 0), new DateTime(2020, 2, 01, 17, 0, 0), new DateTime(2020, 2, 01, 12, 0, 0), new DateTime(2020, 2, 01, 13, 0, 0), "TimeOff"),
                new WorkDay("Monday", 1, false, new DateTime(2020, 2, 2, 8, 0, 0), new DateTime(2020, 2, 2, 17, 0, 0), new DateTime(2020, 2, 2, 12, 0, 0), new DateTime(2020, 2, 2, 13, 0, 0), "TimeOff"),
                new WorkDay("Tuesday", 2, true, new DateTime(2020, 2, 3, 8, 0, 0), new DateTime(2020, 2, 3, 17, 0, 0), new DateTime(2020, 2, 3, 12, 0, 0), new DateTime(2020, 2, 3, 13, 0, 0), "AddBreak"),
                new WorkDay("Wednesday", 3, true, new DateTime(2020, 2, 4, 8, 0, 0), new DateTime(2020, 2, 4, 17, 0, 0), new DateTime(2020, 2, 4, 12, 0, 0), new DateTime(2020, 2, 4, 13, 0, 0), "AddBreak"),
                new WorkDay("Thursday", 4, true, new DateTime(2020, 2, 5, 8, 0, 0), new DateTime(2020, 2, 5, 17, 0, 0), new DateTime(2020, 2, 5, 12, 0, 0), new DateTime(2020, 2, 5, 13, 0, 0), "AddBreak"),
                new WorkDay("Friday", 5, true, new DateTime(2020, 2, 6, 8, 0, 0), new DateTime(2020, 2, 6, 17, 0, 0), new DateTime(2020, 2, 6, 12, 0, 0), new DateTime(2020, 2, 6, 13, 0, 0), "RemoveBreak"),
                new WorkDay("Saturday", 6, true, new DateTime(2020, 2, 7, 8, 0, 0), new DateTime(2020, 2, 7, 17, 0, 0), new DateTime(2020, 2, 7, 12, 0, 0), new DateTime(2020, 2, 7, 13, 0, 0), "AddBreak")
            };

            List<WorkDay> workDays4 = new List<WorkDay>
            {
                new WorkDay("Sunday", 0, true, new DateTime(2020, 2, 01, 10, 0, 0), new DateTime(2020, 2, 01, 19, 0, 0), new DateTime(2020, 2, 01, 14, 0, 0), new DateTime(2020, 2, 01, 15, 0, 0), "AddBreak"),
                new WorkDay("Monday", 1, false, new DateTime(2020, 2, 2, 10, 0, 0), new DateTime(2020, 2, 2, 19, 0, 0), new DateTime(2020, 2, 2, 14, 0, 0), new DateTime(2020, 2, 2, 15, 0, 0), "TimeOff"),
                new WorkDay("Tuesday", 2, true, new DateTime(2020, 2, 3, 10, 0, 0), new DateTime(2020, 2, 3, 19, 0, 0), new DateTime(2020, 2, 3, 14, 0, 0), new DateTime(2020, 2, 3, 15, 0, 0), "AddBreak"),
                new WorkDay("Wednesday", 3, true, new DateTime(2020, 2, 4, 10, 0, 0), new DateTime(2020, 2, 4, 19, 0, 0), new DateTime(2020, 2, 4, 14, 0, 0), new DateTime(2020, 2, 4, 15, 0, 0), "AddBreak"),
                new WorkDay("Thursday", 4, true, new DateTime(2020, 2, 5, 10, 0, 0), new DateTime(2020, 2, 5, 19, 0, 0), new DateTime(2020, 2, 5, 14, 0, 0), new DateTime(2020, 2, 5, 15, 0, 0), "AddBreak"),
                new WorkDay("Friday", 5, true, new DateTime(2020, 2, 6, 10, 0, 0), new DateTime(2020, 2, 6, 19, 0, 0), new DateTime(2020, 2, 6, 14, 0, 0), new DateTime(2020, 2, 6, 15, 0, 0), "RemoveBreak"),
                new WorkDay("Saturday", 6, false, new DateTime(2020, 2, 7, 10, 0, 0), new DateTime(2020, 2, 7, 19, 0, 0), new DateTime(2020, 2, 7, 14, 0, 0), new DateTime(2020, 2, 7, 15, 0, 0), "TimeOff")
            };

            List<WorkDay> workDays5 = new List<WorkDay>
            {
                new WorkDay("Sunday", 0, false, new DateTime(2020, 2, 01, 10, 0, 0), new DateTime(2020, 2, 01, 19, 0, 0), new DateTime(2020, 2, 01, 14, 0, 0), new DateTime(2020, 2, 01, 15, 0, 0), "TimeOff"),
                new WorkDay("Monday", 1, false, new DateTime(2020, 2, 2, 10, 0, 0), new DateTime(2020, 2, 2, 19, 0, 0), new DateTime(2020, 2, 2, 14, 0, 0), new DateTime(2020, 2, 2, 15, 0, 0), "TimeOff"),
                new WorkDay("Tuesday", 2, true, new DateTime(2020, 2, 3, 10, 0, 0), new DateTime(2020, 2, 3, 19, 0, 0), new DateTime(2020, 2, 3, 14, 0, 0), new DateTime(2020, 2, 3, 15, 0, 0), "AddBreak"),
                new WorkDay("Wednesday", 3, true, new DateTime(2020, 2, 4, 10, 0, 0), new DateTime(2020, 2, 4, 19, 0, 0), new DateTime(2020, 2, 4, 14, 0, 0), new DateTime(2020, 2, 4, 15, 0, 0), "AddBreak"),
                new WorkDay("Thursday", 4, true, new DateTime(2020, 2, 5, 10, 0, 0), new DateTime(2020, 2, 5, 19, 0, 0), new DateTime(2020, 2, 5, 14, 0, 0), new DateTime(2020, 2, 5, 15, 0, 0), "AddBreak"),
                new WorkDay("Friday", 5, true, new DateTime(2020, 2, 6, 10, 0, 0), new DateTime(2020, 2, 6, 19, 0, 0), new DateTime(2020, 2, 6, 14, 0, 0), new DateTime(2020, 2, 6, 15, 0, 0), "RemoveBreak"),
                new WorkDay("Saturday", 6, true, new DateTime(2020, 2, 7, 10, 0, 0), new DateTime(2020, 2, 7, 19, 0, 0), new DateTime(2020, 2, 7, 14, 0, 0), new DateTime(2020, 2, 7, 15, 0, 0), "AddBreak")
            };

            List<WorkDay> workDays6 = new List<WorkDay>
            {
                new WorkDay("Sunday", 0, true, new DateTime(2020, 2, 01, 12, 0, 0), new DateTime(2020, 2, 01, 21, 0, 0), new DateTime(2020, 2, 01, 16, 0, 0), new DateTime(2020, 2, 01, 17, 0, 0), "AddBreak"),
                new WorkDay("Monday", 1, false, new DateTime(2020, 2, 2, 12, 0, 0), new DateTime(2020, 2, 2, 21, 0, 0), new DateTime(2020, 2, 2, 16, 0, 0), new DateTime(2020, 2, 2, 17, 0, 0), "TimeOff"),
                new WorkDay("Tuesday", 2, false, new DateTime(2020, 2, 3, 12, 0, 0), new DateTime(2020, 2, 3, 21, 0, 0), new DateTime(2020, 2, 3, 16, 0, 0), new DateTime(2020, 2, 3, 17, 0, 0), "TimeOff"),
                new WorkDay("Wednesday", 3, true, new DateTime(2020, 2, 4, 12, 0, 0), new DateTime(2020, 2, 4, 21, 0, 0), new DateTime(2020, 2, 4, 16, 0, 0), new DateTime(2020, 2, 4, 17, 0, 0), "AddBreak"),
                new WorkDay("Thursday", 4, true, new DateTime(2020, 2, 5, 12, 0, 0), new DateTime(2020, 2, 5, 21, 0, 0), new DateTime(2020, 2, 5, 16, 0, 0), new DateTime(2020, 2, 5, 17, 0, 0), "AddBreak"),
                new WorkDay("Friday", 5, true, new DateTime(2020, 2, 6, 12, 0, 0), new DateTime(2020, 2, 6, 21, 0, 0), new DateTime(2020, 2, 6, 16, 0, 0), new DateTime(2020, 2, 6, 17, 0, 0), "RemoveBreak"),
                new WorkDay("Saturday", 6, true, new DateTime(2020, 2, 7, 12, 0, 0), new DateTime(2020, 2, 7, 21, 0, 0), new DateTime(2020, 2, 7, 16, 0, 0), new DateTime(2020, 2, 7, 17, 0, 0), "AddBreak")
            };

            List<Doctor> doctors = new List<Doctor>
            {
                new Doctor("Nembo Lukeni", "Male", "NemboLukni", 1, 1, "#ea7a57", "MBBS, DMRD", "generalmedicine", "10+ years", "Senior Specialist", "Shift1", "nembo36@sample.com", "(206) 555-9482", "busy", "08:00", "17:00", new int[] { 0, 2, 3, 4, 5 }, workDays),
                new Doctor("Mollie Cobb", "Female", "MollieCobb", 2, 2, "#7fa900", "MBBS, MD PAEDIATRICS, DM NEUROLOGY", "neurology", "2+ years", "Junior Specialist", "Shift2", "mollie65@rpy.com", "(206) 555-3412", "available", "10:00", "19:00", new int[] { 0, 1, 2, 3, 4 }, workDays1),
                new Doctor("Yara Barros", "Female", "YaraBarros", 3, 1, "#fec200", "MBBS, DNB (FAMILY MEDICINE)", "generalmedicine", "8+ years", "Senior Specialist", "Shift3", "yara105@sample.com", "(206) 555-8122", "away", "12:00", "21:00", new int[] { 1, 2, 3, 4, 5 }, workDays2),
                new Doctor("Paul Walker", "Male", "PaulWalker", 4, 3, "#865fcf", "MBBS, MD (Dermatology)", "dermatology", "10+ years", "Senior Specialist", "Shift1", "paul39@mail.com", "(071) 555-4848", "busy", "08:00", "17:00", new int[] { 2, 3, 4, 5, 6 }, workDays3),
                new Doctor("Amelia Edwards", "Female", "AmeliaEdwards", 5, 4, "#1aaa55", "MBBS, MD", "orthopedics", "10+ years", "Junior Specialist", "Shift2", "amelia101@rpy.com", "(071) 555-7773", "available", "10:00", "19:00", new int[] { 0, 2, 3, 4, 5 }, workDays4),
                new Doctor("Alexa Richardson", "Female", "AlexaRichardson", 6, 5, "#1aaa55", "MBBS, MD", "diabetology", "1+ years", "Practitioner", "Shift2", "alexa55@sample.com", "(071) 555-5598", "busy", "10:00", "19:00", new int[] { 2, 3, 4, 5, 6 }, workDays5),
                new Doctor("Amelia Nout Golstein", "Male", "NoutGolstein", 7, 6, "#00bdae", "MS", "cardiology", "2+ years", "Junior Specialist", "Shift3", "nout49@rpy.com", "(206) 555-1189", "busy", "12:00", "21:00", new int[] { 0, 3, 4, 5, 6 }, workDays6)
            };

            return doctors;
        }

        // GET: api/Doctores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _context.Doctor.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

        // PUT: api/Doctores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

        // POST: api/Doctores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            _context.Doctor.Add(doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { id = doctor.Id }, doctor);
        }

        // DELETE: api/Doctores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctor.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctor.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctor.Any(e => e.Id == id);
        }
    }
}
