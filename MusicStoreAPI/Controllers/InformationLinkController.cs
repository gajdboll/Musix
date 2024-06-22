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
    public class InformationLinkController : ControllerBase
    {
        private readonly MusicStoreAPIContext _context;

        public InformationLinkController(MusicStoreAPIContext context)
        {
            _context = context;
        }

        // GET: api/InformationLink
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InformationLinks>>> GetInformationLinks()
        {
            return await _context.InformationLinks.ToListAsync();
        }

        // GET: api/InformationLink/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InformationLinks>> GetInformationLinks(int id)
        {
            var informationLinks = await _context.InformationLinks.FindAsync(id);

            if (informationLinks == null)
            {
                return NotFound();
            }

            return informationLinks;
        }

        // PUT: api/InformationLink/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInformationLinks(int id, InformationLinks informationLinks)
        {
            if (id != informationLinks.Id)
            {
                return BadRequest();
            }

            _context.Entry(informationLinks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformationLinksExists(id))
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

        // POST: api/InformationLink
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InformationLinks>> PostInformationLinks(InformationLinks informationLinks)
        {
            _context.InformationLinks.Add(informationLinks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInformationLinks", new { id = informationLinks.Id }, informationLinks);
        }

        // DELETE: api/InformationLink/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInformationLinks(int id)
        {
            var informationLinks = await _context.InformationLinks.FindAsync(id);
            if (informationLinks == null)
            {
                return NotFound();
            }

            _context.InformationLinks.Remove(informationLinks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InformationLinksExists(int id)
        {
            return _context.InformationLinks.Any(e => e.Id == id);
        }
    }
}
