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
    public class WebHeaderController : Controller
    {
        private readonly MusicStoreAPIContext _context;

        public WebHeaderController(MusicStoreAPIContext context)
        {
            _context = context;
        }

        // GET: WebHeader
        public async Task<IActionResult> Index()
        {
            return View(await _context.WebHeaders.ToListAsync());
        }

        // GET: WebHeader/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webHeaders = await _context.WebHeaders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webHeaders == null)
            {
                return NotFound();
            }

            return View(webHeaders);
        }

        // GET: WebHeader/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WebHeader/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WebSiteContent,WebSiteLink,Position,Name,Descriptions,Id,isActive,DateAdded,ModificationDate,DateOfDelete")] WebHeaders webHeaders)
        {
            if (ModelState.IsValid)
            {
                if (_context.TermsAndCondition.Any(m => m.Position == webHeaders.Position))
                {
                    ModelState.AddModelError("Position", "A Position item with this number already exists.");
                    return View(webHeaders);
                }
                webHeaders.DateAdded = DateTime.Now;
                webHeaders.ModificationDate = DateTime.Now;
                _context.Add(webHeaders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(webHeaders);
        }

        // GET: WebHeader/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webHeaders = await _context.WebHeaders.FindAsync(id);
            if (webHeaders == null)
            {
                return NotFound();
            }
            return View(webHeaders);
        }

        // POST: WebHeader/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WebSiteContent,WebSiteLink,Position,Name,Descriptions,Id,isActive,DateAdded,ModificationDate,DateOfDelete")] WebHeaders webHeaders)
        {
            if (id != webHeaders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (_context.TermsAndCondition.Any(m => m.Position == webHeaders.Position))
                {
                    ModelState.AddModelError("Position", "A Position item with this number already exists.");
                    return View(webHeaders);
                }

                try
                {
                    var existingHeader = await _context.WebHeaders.FindAsync(id);

                    if (existingHeader == null)
                    {
                        return NotFound();
                    }

                    // update all the fields
                    existingHeader.Position = webHeaders.Position;
                    existingHeader.Name = webHeaders.Name;
                    existingHeader.Descriptions = webHeaders.Descriptions;
                    existingHeader.isActive = webHeaders.isActive;
                    existingHeader.ModificationDate = DateTime.Now;

                    _context.Update(existingHeader);
                    await _context.SaveChangesAsync();
              
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebHeadersExists(webHeaders.Id))
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
            return View(webHeaders);
        }

        // GET: WebHeader/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var webHeaders = await _context.WebHeaders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (webHeaders == null)
            {
                return NotFound();
            }

            return View(webHeaders);
        }

        // POST: WebHeader/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var webHeaders = await _context.WebHeaders.FindAsync(id);
            if (webHeaders != null)
            {
                webHeaders.isActive = false;
                webHeaders.DateOfDelete = DateTime.Now;
                _context.WebHeaders.Update(webHeaders);
                await _context.SaveChangesAsync();
            }

             return RedirectToAction(nameof(Index));
        }

        private bool WebHeadersExists(int id)
        {
            return _context.WebHeaders.Any(e => e.Id == id);
        }
    }
}
