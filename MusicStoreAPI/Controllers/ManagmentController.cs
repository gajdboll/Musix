using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStoreAPI.Data;
using MusicStoreAPI.Models.CMS;

namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagmentController : ControllerBase
    {
        private readonly MusicStoreAPIContext _context;

        public ManagmentController(MusicStoreAPIContext context)
        {
            _context = context;
        }

        // GET: api/Managment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Managment>>> GetManagment()
        {
            return await _context.Managment.ToListAsync();
        }

        // GET: api/Managment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Managment>> GetManagment(int id)
        {
            var managment = await _context.Managment.FindAsync(id);

            if (managment == null)
            {
                return NotFound();
            }

            return managment;
        }

        // PUT: api/Managment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagment(int id, Managment managment)
        {
            if (id != managment.Id)
            {
                return BadRequest();
            }

            _context.Entry(managment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagmentExists(id))
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

        // POST: api/Managment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Managment>> PostManagment(Managment managment)
        {
            _context.Managment.Add(managment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManagment", new { id = managment.Id }, managment);
        }

        // DELETE: api/Managment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManagment(int id)
        {
            var managment = await _context.Managment.FindAsync(id);
            if (managment == null)
            {
                return NotFound();
            }

            _context.Managment.Remove(managment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManagmentExists(int id)
        {
            return _context.Managment.Any(e => e.Id == id);
        }
    }
}
