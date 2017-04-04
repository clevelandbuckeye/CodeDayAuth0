using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullMVCWebSite.Data;
using FullMVCWebSite.Models;
using Microsoft.AspNetCore.Authorization;

namespace FullMVCWebSite.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/UserProfiles")]
    public class UserProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserProfiles
        [HttpGet()]
        public IEnumerable<UserProfile> GetUserProfiles()
        {

            return _context.UserProfiles;
        }

        // GET: api/UserProfiles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserProfile([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userProfile = await _context.UserProfiles.SingleOrDefaultAsync(m => m.Id == id);

            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }

        //// PUT: api/UserProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserProfile([FromRoute] long id, [FromBody] UserProfile userProfile)
        {
            UserProfile j = new UserProfile();
            j.Id = 1;
            j.Name = "bryan";
            j.Description = "coder";
            userProfile = j;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(userProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProfileExists(id))
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

        // POST: api/UserProfiles
        [HttpPost]
        public async Task<IActionResult> PostUserProfile([FromBody] UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserProfile", new { id = userProfile.Id }, userProfile);
        }

        // DELETE: api/UserProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProfile([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userProfile = await _context.UserProfiles.SingleOrDefaultAsync(m => m.Id == id);
            if (userProfile == null)
            {
                return NotFound();
            }

            _context.UserProfiles.Remove(userProfile);
            await _context.SaveChangesAsync();

            return Ok(userProfile);
        }

        private bool UserProfileExists(long id)
        {
            return _context.UserProfiles.Any(e => e.Id == id);
        }
    }
}