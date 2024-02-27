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
    public class EvenTypesController : ControllerBase
    {
        private readonly FinalContext _context;

        public EvenTypesController(FinalContext context)
        {
            _context = context;
        }

        // GET: api/EvenTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvenType>>> GetEvenTypes()
        {
            return await _context.EvenTypes.ToListAsync();
        }

        // GET: api/EvenTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EvenType>> GetEvenType(int id)
        {
            var evenType = await _context.EvenTypes.FindAsync(id);

            if (evenType == null)
            {
                return NotFound();
            }

            return evenType;
        }

        // PUT: api/EvenTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvenType(int id, EvenType evenType)
        {
            if (id != evenType.EvenTypeId)
            {
                return BadRequest();
            }

            _context.Entry(evenType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvenTypeExists(id))
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

        // POST: api/EvenTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EvenType>> PostEvenType(EvenType evenType)
        {
            _context.EvenTypes.Add(evenType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvenType", new { id = evenType.EvenTypeId }, evenType);
        }

        // DELETE: api/EvenTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvenType(int id)
        {
            var evenType = await _context.EvenTypes.FindAsync(id);
            if (evenType == null)
            {
                return NotFound();
            }

            _context.EvenTypes.Remove(evenType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EvenTypeExists(int id)
        {
            return _context.EvenTypes.Any(e => e.EvenTypeId == id);
        }
    }
}
