using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoApp.Data;
using DemoApp.Models.Student;

namespace DemoApp.Controllers
{
    [Produces("application/json")]
    [Route("api/APITest")]
    public class APITestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public APITestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/APITest
        [HttpGet]
        public IEnumerable<PersonalDetail> GetPersonalDetail()
        {
            List<PersonalDetail> StudentListData = new List<PersonalDetail>
            {
            new PersonalDetail{RegNo = "2017-0001", Name = "Nishan", Address= "Kathmandu", PhoneNo = "9849845061", AdmissionDate = DateTime.Now },
            new PersonalDetail{RegNo = "2017-0002", Name = "Namrata Rai", Address= "Bhaktapur", PhoneNo = "9849845062", AdmissionDate = DateTime.Now},
             new PersonalDetail{RegNo = "2017-0003", Name = "Abdul Kalam", Address= "Pokhara", PhoneNo = "9849845063", AdmissionDate = DateTime.Now},
            new PersonalDetail{RegNo = "2017-0004", Name = "Sunil Shrestha", Address= "Biratnagar", PhoneNo = "9849845064", AdmissionDate = DateTime.Now},
            };

            return StudentListData;
            //return _context.PersonalDetail;
        }

        // GET: api/APITest/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonalDetail([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personalDetail = await _context.PersonalDetail.SingleOrDefaultAsync(m => m.RegNo == id);

            if (personalDetail == null)
            {
                return NotFound();
            }

            return Ok(personalDetail);
        }

        // PUT: api/APITest/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalDetail([FromRoute] string id, [FromBody] PersonalDetail personalDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personalDetail.RegNo)
            {
                return BadRequest();
            }

            _context.Entry(personalDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalDetailExists(id))
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

        // POST: api/APITest
        [HttpPost]
        public async Task<IActionResult> PostPersonalDetail([FromBody] PersonalDetail personalDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonalDetail.Add(personalDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalDetail", new { id = personalDetail.RegNo }, personalDetail);
        }

        // DELETE: api/APITest/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalDetail([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personalDetail = await _context.PersonalDetail.SingleOrDefaultAsync(m => m.RegNo == id);
            if (personalDetail == null)
            {
                return NotFound();
            }

            _context.PersonalDetail.Remove(personalDetail);
            await _context.SaveChangesAsync();

            return Ok(personalDetail);
        }

        private bool PersonalDetailExists(string id)
        {
            return _context.PersonalDetail.Any(e => e.RegNo == id);
        }
    }
}