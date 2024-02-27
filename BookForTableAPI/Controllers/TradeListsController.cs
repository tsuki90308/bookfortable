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
    public class TradeListsController : ControllerBase
    {
        private readonly FinalContext _context;

        public TradeListsController(FinalContext context)
        {
            _context = context;
        }

        // GET: api/TradeLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TradeList>>> GetTradeLists()
        {
            return await _context.TradeLists.ToListAsync();
        }

        // GET: api/TradeLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TradeList>> GetTradeList(int id)
        {
            var tradeList = await _context.TradeLists.FindAsync(id);

            if (tradeList == null)
            {
                return NotFound();
            }

            return tradeList;
        }

        // PUT: api/TradeLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTradeList(int id, TradeList tradeList)
        {
            if (id != tradeList.TradeListId)
            {
                return BadRequest();
            }

            _context.Entry(tradeList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TradeListExists(id))
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

        // POST: api/TradeLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TradeList>> PostTradeList(TradeList tradeList)
        {
            _context.TradeLists.Add(tradeList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTradeList", new { id = tradeList.TradeListId }, tradeList);
        }

        // DELETE: api/TradeLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradeList(int id)
        {
            var tradeList = await _context.TradeLists.FindAsync(id);
            if (tradeList == null)
            {
                return NotFound();
            }

            _context.TradeLists.Remove(tradeList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TradeListExists(int id)
        {
            return _context.TradeLists.Any(e => e.TradeListId == id);
        }
    }
}
