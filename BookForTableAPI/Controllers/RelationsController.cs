﻿using System;
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
    public class RelationsController : ControllerBase
    {
        private readonly FinalContext _context;

        public RelationsController(FinalContext context)
        {
            _context = context;
        }

        // GET: api/Relations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Relation>>> GetRelations()
        {
            return await _context.Relations.ToListAsync();
        }

        // GET: api/Relations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Relation>> GetRelation(int id)
        {
            var relation = await _context.Relations.FindAsync(id);

            if (relation == null)
            {
                return NotFound();
            }

            return relation;
        }

        // PUT: api/Relations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelation(int id, Relation relation)
        {
            if (id != relation.SortId)
            {
                return BadRequest();
            }

            _context.Entry(relation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelationExists(id))
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

        // POST: api/Relations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Relation>> PostRelation(Relation relation)
        {
            _context.Relations.Add(relation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRelation", new { id = relation.SortId }, relation);
        }

        // DELETE: api/Relations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelation(int id)
        {
            var relation = await _context.Relations.FindAsync(id);
            if (relation == null)
            {
                return NotFound();
            }

            _context.Relations.Remove(relation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RelationExists(int id)
        {
            return _context.Relations.Any(e => e.SortId == id);
        }
    }
}
