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
    public class WebHeaderController : ControllerBase
    {
        private readonly MusicStoreAPIContext _context;

        public WebHeaderController(MusicStoreAPIContext context)
        {
            _context = context;
        }

        // GET: api/WebHeader
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebHeaders>>> GetWebHeaders()
        {
          if (_context.WebHeaders == null)
          {
              return NotFound();
          }
            return await _context.WebHeaders.ToListAsync();
        }

        // GET: api/WebHeader/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WebHeaders>> GetWebHeaders(int id)
        {
          if (_context.WebHeaders == null)
          {
              return NotFound();
          }
            var webHeaders = await _context.WebHeaders.FindAsync(id);

            if (webHeaders == null)
            {
                return NotFound();
            }

            return webHeaders;
        }

        // PUT: api/WebHeader/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWebHeaders(int id, WebHeaders webHeaders)
        {
            if (id != webHeaders.Id)
            {
                return BadRequest();
            }

            _context.Entry(webHeaders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebHeadersExists(id))
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

        // POST: api/WebHeader
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WebHeaders>> PostWebHeaders(WebHeaders webHeaders)
        {
          if (_context.WebHeaders == null)
          {
              return Problem("Entity set 'MusicStoreAPIContext.WebHeaders'  is null.");
          }
            _context.WebHeaders.Add(webHeaders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWebHeaders", new { id = webHeaders.Id }, webHeaders);
        }

        // DELETE: api/WebHeader/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWebHeaders(int id)
        {
            if (_context.WebHeaders == null)
            {
                return NotFound();
            }
            var webHeaders = await _context.WebHeaders.FindAsync(id);
            if (webHeaders == null)
            {
                return NotFound();
            }

            _context.WebHeaders.Remove(webHeaders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WebHeadersExists(int id)
        {
            return (_context.WebHeaders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
