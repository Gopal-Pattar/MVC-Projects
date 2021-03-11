using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestingGuid.Models;

namespace TestingGuid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly TestingContext _context;

        public EmployeeController(TestingContext context)
        {
            _context = context;
        }

        // GET: api/Testings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Testing>>> GetTestings()
        {
            return await _context.Testings.ToListAsync();
        }

        // GET: api/Testings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Testing>> GetTesting(int id)
        {
            var testing = await _context.Testings.FindAsync(id);

            if (testing == null)
            {
                return NotFound();
            }

            return testing;
        }

        // PUT: api/Testings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTesting(int id, Testing testing)
        {
            if (id != testing.EID)
            {
                return BadRequest();
            }

            _context.Entry(testing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestingExists(id))
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

        // POST: api/Testings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Testing>> PostTesting(Testing testing)
        {
            _context.Testings.Add(testing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTesting", new { id = testing.EID }, testing);
        }

        // DELETE: api/Testings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTesting(int id)
        {
            var testing = await _context.Testings.FindAsync(id);
            if (testing == null)
            {
                return NotFound();
            }

            _context.Testings.Remove(testing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestingExists(int id)
        {
            return _context.Testings.Any(e => e.EID == id);
        }
    }
}
