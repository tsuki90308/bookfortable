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
    public class MyCouponsController : ControllerBase
    {
        private readonly FinalContext _context;

        public MyCouponsController(FinalContext context)
        {
            _context = context;
        }

        // GET: api/MyCoupons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyCoupon>>> GetMyCoupons()
        {
            return await _context.MyCoupons.ToListAsync();
        }

        // GET: api/MyCoupons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyCoupon>> GetMyCoupon(int id)
        {
            var myCoupon = await _context.MyCoupons.FindAsync(id);

            if (myCoupon == null)
            {
                return NotFound();
            }

            return myCoupon;
        }

        // PUT: api/MyCoupons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyCoupon(int id, MyCoupon myCoupon)
        {
            if (id != myCoupon.McId)
            {
                return BadRequest();
            }

            _context.Entry(myCoupon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyCouponExists(id))
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

        // POST: api/MyCoupons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MyCoupon>> PostMyCoupon(MyCoupon myCoupon)
        {
            _context.MyCoupons.Add(myCoupon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyCoupon", new { id = myCoupon.McId }, myCoupon);
        }

        // DELETE: api/MyCoupons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyCoupon(int id)
        {
            var myCoupon = await _context.MyCoupons.FindAsync(id);
            if (myCoupon == null)
            {
                return NotFound();
            }

            _context.MyCoupons.Remove(myCoupon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyCouponExists(int id)
        {
            return _context.MyCoupons.Any(e => e.McId == id);
        }
    }
}
