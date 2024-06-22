using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStoreAPI.Data;
using MusicStoreAPI.Models.CMS;

namespace MusicAdminPortal.Controllers
{
    public class MusicStoreAddressController : Controller
    {
        private readonly MusicStoreAPIContext _context;

        public MusicStoreAddressController(MusicStoreAPIContext context)
        {
            _context = context;
        }

        // GET: MusicStoreAddress
        public async Task<IActionResult> Index()
        {
              return _context.MusicStoreAddress != null ? 
                          View(await _context.MusicStoreAddress.ToListAsync()) :
                          Problem("Entity set 'MusicStoreAPIContext.MusicStoreAddress'  is null.");
        }

        // GET: MusicStoreAddress/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MusicStoreAddress == null)
            {
                return NotFound();
            }

            var musicStoreAddress = await _context.MusicStoreAddress
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicStoreAddress == null)
            {
                return NotFound();
            }

            return View(musicStoreAddress);
        }

        // GET: MusicStoreAddress/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MusicStoreAddress/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MusicSentence,Adres1,Adres2,PhoneNumer,EmailAdres,Position,Name,Descriptions,Id,isActive,DateAdded,ModificationDate,DateOfDelete")] MusicStoreAddress musicStoreAddress)
        {
            if (ModelState.IsValid)
            {
                if (_context.TermsAndCondition.Any(m => m.Position == musicStoreAddress.Position))
                {
                    ModelState.AddModelError("Position", "A Position item with this number already exists.");
                    return View(musicStoreAddress);
                }

                musicStoreAddress.DateAdded = DateTime.Now;
                musicStoreAddress.ModificationDate = DateTime.Now;
                _context.Add(musicStoreAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musicStoreAddress);
        }

        // GET: MusicStoreAddress/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MusicStoreAddress == null)
            {
                return NotFound();
            }

            var musicStoreAddress = await _context.MusicStoreAddress.FindAsync(id);
            if (musicStoreAddress == null)
            {
                return NotFound();
            }
            return View(musicStoreAddress);
        }

        // POST: MusicStoreAddress/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MusicSentence,Adres1,Adres2,PhoneNumer,EmailAdres,Position,Name,Descriptions,Id,isActive,DateAdded,ModificationDate,DateOfDelete")] MusicStoreAddress musicStoreAddress)
        {
            if (id != musicStoreAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (_context.TermsAndCondition.Any(m => m.Position == musicStoreAddress.Position))
                {
                    ModelState.AddModelError("Position", "A Position item with this number already exists.");
                    return View(musicStoreAddress);
                }
                try
                {
                    var existingAddress= await _context.MusicStoreAddress.FindAsync(id);

                    if (existingAddress == null)
                    {
                        return NotFound();
                    }

                    // update all the fields
                    existingAddress.Name = musicStoreAddress.Name;
                    existingAddress.Position = musicStoreAddress.Position;
                    existingAddress.Descriptions = musicStoreAddress.Descriptions;
                    existingAddress.isActive = musicStoreAddress.isActive;
                    existingAddress.ModificationDate = DateTime.Now;

                    _context.Update(musicStoreAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicStoreAddressExists(musicStoreAddress.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(musicStoreAddress);
        }

        // GET: MusicStoreAddress/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MusicStoreAddress == null)
            {
                return NotFound();
            }

            var musicStoreAddress = await _context.MusicStoreAddress
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicStoreAddress == null)
            {
                return NotFound();
            }

            return View(musicStoreAddress);
        }

        // POST: MusicStoreAddress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MusicStoreAddress == null)
            {
                return Problem("Entity set 'MusicStoreAPIContext.MusicStoreAddress'  is null.");
            }
            var musicStoreAddress = await _context.MusicStoreAddress.FindAsync(id);
            if (musicStoreAddress != null)
            {
                musicStoreAddress.isActive = false;
                musicStoreAddress.DateOfDelete = DateTime.Now;

            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicStoreAddressExists(int id)
        {
          return (_context.MusicStoreAddress?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
