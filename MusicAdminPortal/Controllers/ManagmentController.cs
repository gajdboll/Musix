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
    public class ManagmentController : Controller
    {
        private readonly MusicStoreAPIContext _context;

        public ManagmentController(MusicStoreAPIContext context)
        {
            _context = context;
        }

        // GET: Managment
        public async Task<IActionResult> Index()
        {
            return View(await _context.Managment.ToListAsync());
        }

        // GET: Managment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managment = await _context.Managment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (managment == null)
            {
                return NotFound();
            }

            return View(managment);
        }

        // GET: Managment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Managment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManagmentLink,ManagmentIcon,Position,Name,Descriptions,Id,isActive,DateAdded,ModificationDate,DateOfDelete")] Managment managment)
        {
            if (ModelState.IsValid)
            {
                if (_context.TermsAndCondition.Any(m => m.Position == managment.Position))
                {
                    ModelState.AddModelError("Position", "A Position item with this number already exists.");
                    return View(managment);
                }
                managment.DateAdded = DateTime.Now;
                managment.ModificationDate = DateTime.Now;
                _context.Add(managment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(managment);
        }

        // GET: Managment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managment = await _context.Managment.FindAsync(id);
            if (managment == null)
            {
                return NotFound();
            }
            return View(managment);
        }

        // POST: Managment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ManagmentLink,ManagmentIcon,Position,Name,Descriptions,Id,isActive,DateAdded,ModificationDate,DateOfDelete")] Managment managment)
        {
            if (id != managment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (_context.TermsAndCondition.Any(m => m.Position == managment.Position))
                {
                    ModelState.AddModelError("Position", "A Position item with this number already exists.");
                    return View(managment);
                }
                try
                {
                    var existingTop= await _context.Managment.FindAsync(id);

                    if (existingTop == null)
                    {
                        return NotFound();
                    }

                    // update all the fields
                    existingTop.Position = managment.Position;
                    existingTop.Name = managment.Name;
                    existingTop.Descriptions = managment.Descriptions;
                    existingTop.isActive = managment.isActive;
                    existingTop.ModificationDate = DateTime.Now;

                    _context.Update(existingTop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagmentExists(managment.Id))
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
            return View(managment);
        }

        // GET: Managment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managment = await _context.Managment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (managment == null)
            {
                return NotFound();
            }

            return View(managment);
        }

        // POST: Managment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var managment = await _context.Managment.FindAsync(id);
            if (managment != null)
            {
                managment.isActive = false;
                managment.DateOfDelete= DateTime.Now;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagmentExists(int id)
        {
            return _context.Managment.Any(e => e.Id == id);
        }
    }
}
