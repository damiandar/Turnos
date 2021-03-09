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
    public class WaitingListController : ControllerBase
    {
        private readonly TurneraDbContext _context;

        public WaitingListController(TurneraDbContext context)
        {
            _context = context;
        }

        // GET: api/WaitingList
        [HttpGet]
        /*public async Task<ActionResult<IEnumerable<WaitingList>>> GetWaitingList()
        {
            return await _context.WaitingList.ToListAsync();
        }*/
        public List<WaitingList> GetWaitingList()
        {

            List<WaitingList> wait = new List<WaitingList>()
            {
                new WaitingList {Id= 1, Name= "Laura", StartTime= new DateTime(2020, 2, 3, 8, 30, 0), EndTime= new DateTime(2020, 2, 3, 9, 30, 0), Disease= "Sudden loss of vision", DepartmentName= "GENERAL", Treatment= "CHECKUP", DepartmentId= 1, PatientId= 1},
                new WaitingList { Id= 2,Name= "Milka", StartTime= new DateTime(2020, 2, 4, 8, 30, 0), EndTime= new DateTime(2020, 2, 4, 10, 30, 0), Disease= "Bone Fracture", DepartmentName= "ORTHOPEDICS", Treatment= "SURGERY", DepartmentId= 4, PatientId= 2 },
                new WaitingList { Id= 3, Name= "Adams", StartTime= new DateTime(2020, 2, 4, 9, 30, 0), EndTime= new DateTime(2020, 2, 4, 10, 30, 0), Disease= "Skin Hives", DepartmentName= "DERMATOLOGY", Treatment= "CHECKUP", DepartmentId= 3, PatientId= 3 },
                new WaitingList { Id= 4, Name= "Janet", StartTime= new DateTime(2020, 2, 3, 11, 0, 0), EndTime= new DateTime(2020, 2, 3, 12, 30, 0), Disease= "Frequent urination", DepartmentName= "DIABETALOGY", Treatment= "DIALOGIS", DepartmentId= 5, PatientId= 4 },
                new WaitingList { Id= 5, Name= "Mercy", StartTime= new DateTime(2020, 2, 3, 11, 0, 0), EndTime= new DateTime(2020, 2, 3, 12, 30, 0), Disease= "Muscle weakness", DepartmentName= "NEUROLOGY", Treatment= "DIAGNOSIS", DepartmentId= 2, PatientId= 5 },
                new WaitingList { Id= 6, Name= "Richa", StartTime= new DateTime(2020, 2, 3, 11, 0, 0), EndTime= new DateTime(2020, 2, 3, 12, 30, 0), Disease= "Shortness of breath", DepartmentName= "CARDIOLOGY", Treatment= "REGULAR CHECKUP", DepartmentId= 6, PatientId= 6 },
                new WaitingList { Id= 7, Name= "Richa", StartTime= new DateTime(2020, 2, 3, 8, 30, 0), EndTime= new DateTime(2020, 2, 3, 9, 30, 0), Disease= "Sudden loss of vision", DepartmentName= "GENERAL", Treatment= "CHECKUP", DepartmentId= 1, PatientId= 6 },
                new WaitingList { Id= 8, Name= "Mercy", StartTime= new DateTime(2020, 8, 4, 8, 30, 0), EndTime= new DateTime(2020, 8, 4, 10, 30, 0), Disease= "Bone Fracture", DepartmentName= "ORTHOPEDICS", Treatment= "SURGERY", DepartmentId= 4, PatientId= 5},
                new WaitingList { Id= 9, Name= "Janet", StartTime= new DateTime(2020, 2, 4, 9, 30, 0), EndTime= new DateTime(2020, 2, 4, 10, 30, 0), Disease= "Skin Hives", DepartmentName= "DERMATOLOGY", Treatment= "CHECKUP", DepartmentId= 3, PatientId= 4 }

            };
            return wait;

        }

        // GET: api/WaitingList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WaitingList>> GetWaitingList(int id)
        {
            var waitingList = await _context.WaitingList.FindAsync(id);

            if (waitingList == null)
            {
                return NotFound();
            }

            return waitingList;
        }

        // PUT: api/WaitingList/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaitingList(int id, WaitingList waitingList)
        {
            if (id != waitingList.Id)
            {
                return BadRequest();
            }

            _context.Entry(waitingList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaitingListExists(id))
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

        // POST: api/WaitingList
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WaitingList>> PostWaitingList(WaitingList waitingList)
        {
            _context.WaitingList.Add(waitingList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaitingList", new { id = waitingList.Id }, waitingList);
        }

        // DELETE: api/WaitingList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWaitingList(int id)
        {
            var waitingList = await _context.WaitingList.FindAsync(id);
            if (waitingList == null)
            {
                return NotFound();
            }

            _context.WaitingList.Remove(waitingList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WaitingListExists(int id)
        {
            return _context.WaitingList.Any(e => e.Id == id);
        }
    }
}
