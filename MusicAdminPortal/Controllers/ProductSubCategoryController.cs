using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStoreAPI.Data;
using MusicStoreAPI.Models.CMS;

namespace MusicAdminPortal.Controllers
{
    public class ProductSubCategoryController : Controller
    {
        private readonly MusicStoreAPIContext _context;

        public ProductSubCategoryController(MusicStoreAPIContext context)
        {
            _context = context;
        }

        // GET: ProductSubCategory
        public async Task<IActionResult> Index()
        {
            var musicStoreAPIContext = _context.ProductSubCategory
                                                     .Include(p => p.ProductCategory);            
            return View(await musicStoreAPIContext.ToListAsync());
        }

        // GET: ProductSubCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSubCategory = await _context.ProductSubCategory
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productSubCategory == null)
            {
                return NotFound();
            }

            return View(productSubCategory);
        }

        // GET: ProductSubCategory/Create
        public IActionResult Create()
        {
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Descriptions");
            return View();
        }

        // POST: ProductSubCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductCategoryId,Name,Descriptions,Id,isActive,DateAdded,ModificationDate,DateOfDelete")] ProductSubCategory productSubCategory)
        {
            if (ModelState.IsValid)
            {
                if (_context.TermsAndCondition.Any(m => m.Position == productSubCategory.Position))
                {
                    ModelState.AddModelError("Position", "A Position item with this number already exists.");
                    return View(productSubCategory);
                }
                productSubCategory.DateAdded = DateTime.Now;
                productSubCategory.ModificationDate = DateTime.Now;
                _context.Add(productSubCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Descriptions", productSubCategory.ProductCategoryId);
            return View(productSubCategory);
        }

        // GET: ProductSubCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSubCategory = await _context.ProductSubCategory.FindAsync(id);
            if (productSubCategory == null)
            {
                return NotFound();
            }
            productSubCategory.ModificationDate = DateTime.Now;

            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Descriptions", productSubCategory.ProductCategoryId);
            return View(productSubCategory);
        }

        // POST: ProductSubCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductCategoryId,Name,Descriptions,Id,isActive,DateAdded,ModificationDate,DateOfDelete")] ProductSubCategory productSubCategory)
        {
            if (id != productSubCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (_context.TermsAndCondition.Any(m => m.Position == productSubCategory.Position))
                {
                    ModelState.AddModelError("Position", "A Position item with this number already exists.");
                    return View(productSubCategory);
                }
                try
                {
                    var existingSub= await _context.ProductSubCategory.FindAsync(id);

                    if (existingSub == null)
                    {
                        return NotFound();
                    }

                    // update all the fields
                    existingSub.Position = productSubCategory.Position;
                    existingSub.ProductCategory = productSubCategory.ProductCategory;
                    existingSub.ProductCategoryId = productSubCategory.ProductCategoryId;
                    existingSub.Name = productSubCategory.Name;
                    existingSub.Descriptions = productSubCategory.Descriptions;
                    existingSub.isActive = productSubCategory.isActive;
                    existingSub.ModificationDate = DateTime.Now;

                    _context.Update(existingSub);
                    await _context.SaveChangesAsync();
                }

                 
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSubCategoryExists(productSubCategory.Id))
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

            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "Id", "Descriptions", productSubCategory.ProductCategoryId);
            return View(productSubCategory);
        }

        // GET: ProductSubCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSubCategory = await _context.ProductSubCategory
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productSubCategory == null)
            {
                return NotFound();
            }
            productSubCategory.DateOfDelete = DateTime.Now;
            return View(productSubCategory);
        }

        // POST: ProductSubCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productSubCategory = await _context.ProductSubCategory.FindAsync(id);
            if (productSubCategory != null)
            {
                 productSubCategory.isActive=false;
                productSubCategory.DateOfDelete = DateTime.Now;

            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSubCategoryExists(int id)
        {
            return _context.ProductSubCategory.Any(e => e.Id == id);
        }
    }
}
