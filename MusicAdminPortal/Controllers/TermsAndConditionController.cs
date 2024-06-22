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
    public class TermsAndConditionController : Controller
    {
        private readonly MusicStoreAPIContext _context;

        public TermsAndConditionController(MusicStoreAPIContext context)
        {
            _context = context;
        }

        // GET: TermsAndCondition
        public async Task<IActionResult> Index()
        {
            return View(await _context.TermsAndCondition.ToListAsync());
        }

        // GET: TermsAndCondition/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termsAndCondition = await _context.TermsAndCondition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (termsAndCondition == null)
            {
                return NotFound();
            }

            return View(termsAndCondition);
        }

        // GET: TermsAndCondition/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TermsAndCondition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Position,Name,Descriptions,Id,isActive,DateAdded,ModificationDate,DateOfDelete")] TermsAndCondition termsAndCondition)
        {
            if (ModelState.IsValid)
            {
                if (_context.TermsAndCondition.Any(m => m.Position == termsAndCondition.Position))
                {
                    ModelState.AddModelError("Position", "A Position item with this number already exists.");
                    return View(termsAndCondition);
                }

                termsAndCondition.DateAdded = DateTime.Now;
                termsAndCondition.ModificationDate = DateTime.Now;

                _context.Add(termsAndCondition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(termsAndCondition);
        }

        // GET: TermsAndCondition/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termsAndCondition = await _context.TermsAndCondition.FindAsync(id);
            if (termsAndCondition == null)
            {
                return NotFound();
            }
            return View(termsAndCondition);
        }

        // POST: TermsAndCondition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Position,Name,Descriptions,isActive")] TermsAndCondition termsAndCondition)
        {
            if (id != termsAndCondition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (_context.TermsAndCondition.Any(m => m.Position == termsAndCondition.Position))
                {
                    ModelState.AddModelError("Position", "A Position item with this number already exists.");
                    return View(termsAndCondition);
                }
                try
                {
                    var existingTermsAndCondition = await _context.TermsAndCondition.FindAsync(id);

                    if (existingTermsAndCondition == null)
                    {
                        return NotFound();
                    }

                    // update all the fields
                    existingTermsAndCondition.Position = termsAndCondition.Position;
                    existingTermsAndCondition.Name = termsAndCondition.Name;
                    existingTermsAndCondition.Descriptions = termsAndCondition.Descriptions;
                    existingTermsAndCondition.isActive = termsAndCondition.isActive;
                    existingTermsAndCondition.ModificationDate = DateTime.Now;

                    _context.Update(existingTermsAndCondition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermsAndConditionExists(termsAndCondition.Id))
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

            return View(termsAndCondition);
        }



        // GET: TermsAndCondition/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termsAndCondition = await _context.TermsAndCondition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (termsAndCondition == null)
            {
                return NotFound();
            }

            return View(termsAndCondition);
        }

        // POST: TermsAndCondition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var termsAndCondition = await _context.TermsAndCondition.FindAsync(id);
            if (termsAndCondition != null)
            {
                termsAndCondition.isActive = false;
                termsAndCondition.DateOfDelete = DateTime.Now;

                _context.TermsAndCondition.Update(termsAndCondition);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        private bool TermsAndConditionExists(int id)
        {
            return _context.TermsAndCondition.Any(e => e.Id == id);
        }
    }
    }
