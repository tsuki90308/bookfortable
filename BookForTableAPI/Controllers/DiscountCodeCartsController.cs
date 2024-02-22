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
    public class DiscountCodeCartsController : ControllerBase
    {
        private readonly FinalContext _context;

        public DiscountCodeCartsController(FinalContext context)
        {
            _context = context;
        }

        // GET: api/DiscountCodeCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscountCodeCart>>> GetDiscountCodeCarts()
        {
            return await _context.DiscountCodeCarts.ToListAsync();
        }

        // GET: api/DiscountCodeCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiscountCodeCart>> GetDiscountCodeCart(int id)
        {
            var discountCodeCart = await _context.DiscountCodeCarts.FindAsync(id);

            if (discountCodeCart == null)
            {
                return NotFound();
            }

            return discountCodeCart;
        }

        // PUT: api/DiscountCodeCarts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscountCodeCart(int id, DiscountCodeCart discountCodeCart)
        {
            if (id != discountCodeCart.DiscountId)
            {
                return BadRequest();
            }

            _context.Entry(discountCodeCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscountCodeCartExists(id))
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

        // POST: api/DiscountCodeCarts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DiscountCodeCart>> PostDiscountCodeCart(DiscountCodeCart discountCodeCart)
        {
            _context.DiscountCodeCarts.Add(discountCodeCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiscountCodeCart", new { id = discountCodeCart.DiscountId }, discountCodeCart);
        }

        // DELETE: api/DiscountCodeCarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscountCodeCart(int id)
        {
            var discountCodeCart = await _context.DiscountCodeCarts.FindAsync(id);
            if (discountCodeCart == null)
            {
                return NotFound();
            }

            _context.DiscountCodeCarts.Remove(discountCodeCart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiscountCodeCartExists(int id)
        {
            return _context.DiscountCodeCarts.Any(e => e.DiscountId == id);
        }
    }
}
