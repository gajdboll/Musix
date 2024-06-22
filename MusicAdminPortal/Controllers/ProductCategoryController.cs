using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStoreAPI.Data;
using MusicStoreAPI.Models.CMS;

namespace MusicAdminPortal.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly MusicStoreAPIContext _context;

        public ProductCategoryController(MusicStoreAPIContext context)
        {
            _context = context;
        }

        // GET: ProductCategory
        public async Task<IActionResult> Index()
        {
            var musicStoreAPIContext = _context.ProductCategory.Include(p => p.WebHeader);
            return View(await musicStoreAPIContext.ToListAsync());
        }

        // GET: ProductCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategory
                .Include(p => p.WebHeader)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }
            productCategory.DateAdded = DateTime.Now;
            productCategory.ModificationDate = DateTime.Now;
            return View(productCategory);
        }

        // GET: ProductCategory/Create
        public IActionResult Create()
        {
            ViewData["WebHeaderId"] = new SelectList(_context.WebHeaders, "Id", "Descriptions");
            return View();
        }

        // POST: ProductCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisplayOrder,Position,WebHeaderId,Name,Descriptions,Id,isActive,DateAdded,ModificationDate,DateOfDelete")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                if (_context.TermsAndCondition.Any(m => m.Position == productCategory.Position))
                {
                    ModelState.AddModelError("Position", "A Position item with this number already exists.");
                    return View(productCategory);
                }
                productCategory.DateAdded = DateTime.Now;
                productCategory.ModificationDate = DateTime.Now;
                _context.Add(productCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WebHeaderId"] = new SelectList(_context.WebHeaders, "Id", "Descriptions", productCategory.WebHeaderId);
            return View(productCategory);
        }

        // GET: ProductCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategory.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
             productCategory.ModificationDate = DateTime.Now;
            ViewData["WebHeaderId"] = new SelectList(_context.WebHeaders, "Id", "Descriptions", productCategory.WebHeaderId);
            return View(productCategory);
        }

        // POST: ProductCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisplayOrder,Position,WebHeaderId,Name,Descriptions,Id,isActive,DateAdded,ModificationDate,DateOfDelete")] ProductCategory productCategory)
        {
            if (id != productCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (_context.TermsAndCondition.Any(m => m.Position == productCategory.Position))
                {
                    ModelState.AddModelError("Position", "A Position item with this number already exists.");
                    return View(productCategory);
                }
                try
                {
                    var existingCategory= await _context.ProductCategory.FindAsync(id);

                    if (existingCategory == null)
                    {
                        return NotFound();
                    }

                    // update all the fields
                    existingCategory.Position = productCategory.Position;
                    existingCategory.WebHeaderId = productCategory.WebHeaderId;
                    existingCategory.Name = productCategory.Name;
                    existingCategory.Descriptions = productCategory.Descriptions;
                    existingCategory.isActive = productCategory.isActive;
                    existingCategory.ModificationDate = DateTime.Now;

                    _context.Update(existingCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCategoryExists(productCategory.Id))
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
            ViewData["WebHeaderId"] = new SelectList(_context.WebHeaders, "Id", "Descriptions", productCategory.WebHeaderId);
            return View(productCategory);
        }

        // GET: ProductCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategory
                .Include(p => p.WebHeader)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // POST: ProductCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productCategory = await _context.ProductCategory.FindAsync(id);
            if (productCategory != null)
            {
                productCategory.isActive = false;
                productCategory.DateOfDelete = DateTime.Now;

            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCategoryExists(int id)
        {
            return _context.ProductCategory.Any(e => e.Id == id);
        }
    }
}
