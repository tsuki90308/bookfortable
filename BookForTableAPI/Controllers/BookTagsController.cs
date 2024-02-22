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
    public class BookTagsController : ControllerBase
    {
        private readonly FinalContext _context;

        public BookTagsController(FinalContext context)
        {
            _context = context;
        }

        // GET: api/BookTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookTag>>> GetBookTags()
        {
            return await _context.BookTags.ToListAsync();
        }

        // GET: api/BookTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookTag>> GetBookTag(int id)
        {
            var bookTag = await _context.BookTags.FindAsync(id);

            if (bookTag == null)
            {
                return NotFound();
            }

            return bookTag;
        }

        // PUT: api/BookTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookTag(int id, BookTag bookTag)
        {
            if (id != bookTag.BtagId)
            {
                return BadRequest();
            }

            _context.Entry(bookTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookTagExists(id))
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

        // POST: api/BookTags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookTag>> PostBookTag(BookTag bookTag)
        {
            _context.BookTags.Add(bookTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookTag", new { id = bookTag.BtagId }, bookTag);
        }

        // DELETE: api/BookTags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookTag(int id)
        {
            var bookTag = await _context.BookTags.FindAsync(id);
            if (bookTag == null)
            {
                return NotFound();
            }

            _context.BookTags.Remove(bookTag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookTagExists(int id)
        {
            return _context.BookTags.Any(e => e.BtagId == id);
        }
    }
}
