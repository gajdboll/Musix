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
    public class MusicStoreAddressController : ControllerBase
    {
        private readonly MusicStoreAPIContext _context;

        public MusicStoreAddressController(MusicStoreAPIContext context)
        {
            _context = context;
        }

        // GET: api/MusicStoreAddress
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicStoreAddress>>> GetMusicStoreAddress()
        {
          if (_context.MusicStoreAddress == null)
          {
              return NotFound();
          }
            return await _context.MusicStoreAddress.ToListAsync();
        }

        // GET: api/MusicStoreAddress/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicStoreAddress>> GetMusicStoreAddress(int id)
        {
          if (_context.MusicStoreAddress == null)
          {
              return NotFound();
          }
            var musicStoreAddress = await _context.MusicStoreAddress.FindAsync(id);

            if (musicStoreAddress == null)
            {
                return NotFound();
            }

            return musicStoreAddress;
        }

        // PUT: api/MusicStoreAddress/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicStoreAddress(int id, MusicStoreAddress musicStoreAddress)
        {
            if (id != musicStoreAddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(musicStoreAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicStoreAddressExists(id))
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

        // POST: api/MusicStoreAddress
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MusicStoreAddress>> PostMusicStoreAddress(MusicStoreAddress musicStoreAddress)
        {
          if (_context.MusicStoreAddress == null)
          {
              return Problem("Entity set 'MusicStoreAPIContext.MusicStoreAddress'  is null.");
          }
            _context.MusicStoreAddress.Add(musicStoreAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusicStoreAddress", new { id = musicStoreAddress.Id }, musicStoreAddress);
        }

        // DELETE: api/MusicStoreAddress/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusicStoreAddress(int id)
        {
            if (_context.MusicStoreAddress == null)
            {
                return NotFound();
            }
            var musicStoreAddress = await _context.MusicStoreAddress.FindAsync(id);
            if (musicStoreAddress == null)
            {
                return NotFound();
            }

            _context.MusicStoreAddress.Remove(musicStoreAddress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicStoreAddressExists(int id)
        {
            return (_context.MusicStoreAddress?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
