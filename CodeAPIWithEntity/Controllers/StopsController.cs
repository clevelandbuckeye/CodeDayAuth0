using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeAPIWithEntity.Models;

namespace CodeAPIWithEntity.Controllers
{
    [Produces("application/json")]
    [Route("api/Stops")]
    public class StopsController : Controller
    {
        private readonly WorldContext _context;

        public StopsController(WorldContext context)
        {
            _context = context;
        }

        // GET: api/Stops
        [HttpGet]
        public IEnumerable<Stop> GetStop()
        {
            return _context.Stops;
        }

        // GET: api/Stops/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStop([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stop = await _context.Stops.SingleOrDefaultAsync(m => m.Id == id);

            if (stop == null)
            {
                return NotFound();
            }

            return Ok(stop);
        }

        // PUT: api/Stops/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStop([FromRoute] long id, [FromBody] Stop stop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stop.Id)
            {
                return BadRequest();
            }

            _context.Entry(stop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StopExists(id))
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

        // POST: api/Stops
        [HttpPost]
        public async Task<IActionResult> PostStop([FromBody] Stop stop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Stops.Add(stop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStop", new { id = stop.Id }, stop);
        }

        // DELETE: api/Stops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStop([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stop = await _context.Stops.SingleOrDefaultAsync(m => m.Id == id);
            if (stop == null)
            {
                return NotFound();
            }

            _context.Stops.Remove(stop);
            await _context.SaveChangesAsync();

            return Ok(stop);
        }

        private bool StopExists(long id)
        {
            return _context.Stops.Any(e => e.Id == id);
        }
    }
}