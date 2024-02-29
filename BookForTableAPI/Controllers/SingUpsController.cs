using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookForTableAPI.Models;

namespace BookForTableAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingUpsController : ControllerBase
    {
        private readonly FinalContext _context;

        public SingUpsController(FinalContext context)
        {
            _context = context;
        }

        // GET: api/SingUps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SingUp>>> GetSingUps()
        {
            return await _context.SingUps.ToListAsync();
        }

        // GET: api/SingUps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SingUp>> GetSingUp(int id)
        {
            var singUp = await _context.SingUps.FindAsync(id);

            if (singUp == null)
            {
                return NotFound();
            }

            return singUp;
        }

        // PUT: api/SingUps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSingUp(int id, SingUp singUp)
        {
            if (id != singUp.SignUpId)
            {
                return BadRequest();
            }

            _context.Entry(singUp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SingUpExists(id))
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

        // POST: api/SingUps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SingUp>> PostSingUp(SingUp singUp)
        {
            _context.SingUps.Add(singUp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSingUp", new { id = singUp.SignUpId }, singUp);
        }

        // DELETE: api/SingUps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSingUp(int id)
        {
            var singUp = await _context.SingUps.FindAsync(id);
            if (singUp == null)
            {
                return NotFound();
            }

            _context.SingUps.Remove(singUp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SingUpExists(int id)
        {
            return _context.SingUps.Any(e => e.SignUpId == id);
        }
    }
}
