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
    public class TermsAndConditionController : ControllerBase
    {
        private readonly MusicStoreAPIContext _context;

        public TermsAndConditionController(MusicStoreAPIContext context)
        {
            _context = context;
        }

        // GET: api/TermsAndCondition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TermsAndCondition>>> GetTermsAndConditions()
        {
          if (_context.TermsAndCondition == null)
          {
              return NotFound();
          }
            return await _context.TermsAndCondition.ToListAsync();
        }

        // GET: api/TermsAndCondition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TermsAndCondition>> GetTermsAndConditions(int id)
        {
          if (_context.TermsAndCondition == null)
          {
              return NotFound();
          }
            var termsAndConditions = await _context.TermsAndCondition.FindAsync(id);

            if (termsAndConditions == null)
            {
                return NotFound();
            }

            return termsAndConditions;
        }

        // PUT: api/TermsAndCondition/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTermsAndConditions(int id, TermsAndCondition termsAndConditions)
        {
            if (id != termsAndConditions.Id)
            {
                return BadRequest();
            }

            _context.Entry(termsAndConditions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TermsAndConditionsExists(id))
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

        // POST: api/TermsAndCondition
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TermsAndCondition>> PostTermsAndConditions(TermsAndCondition termsAndConditions)
        {
          if (_context.TermsAndCondition == null)
          {
              return Problem("Entity set 'MusicStoreAPIContext.TermsAndConditions'  is null.");
          }
            _context.TermsAndCondition.Add(termsAndConditions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTermsAndConditions", new { id = termsAndConditions.Id }, termsAndConditions);
        }

        // DELETE: api/TermsAndCondition/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTermsAndConditions(int id)
        {
            if (_context.TermsAndCondition == null)
            {
                return NotFound();
            }
            var termsAndConditions = await _context.TermsAndCondition.FindAsync(id);
            if (termsAndConditions == null)
            {
                return NotFound();
            }

            _context.TermsAndCondition.Remove(termsAndConditions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TermsAndConditionsExists(int id)
        {
            return (_context.TermsAndCondition?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
