using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.DAL;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    /// <summary>
    /// HTTP Controller for Inventory Model
    /// </summary>
    public class InventoriesController : Controller
    {
        private readonly InventoryManagementContext _context;

        public InventoriesController(InventoryManagementContext context)
        {
            _context = context;
        }

        // GET: Inventories
        public async Task<IActionResult> Index()
        {
            var inventoryManagementContext = _context.Inventories.Include(i => i.Bin).Include(i => i.Product);
            return View(await inventoryManagementContext.ToListAsync());
        }

        // GET: Inventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventories
                .Include(i => i.Bin)
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.InventoryID == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventories/Create
        public IActionResult Create()
        {
            ViewData["BinID"] = new SelectList(_context.Bins, "BinID", "BinName");
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription");
            return View();
        }

        // POST: Inventories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryID,QTY,BinID,ProductID")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventory);
                try
                {
                    await _context.SaveChangesAsync();
                }
                // Exception for invalid Inventory entry
                catch (DbUpdateException ex)
                {
                    // send message to view
                    ModelState.AddModelError(string.Empty, "An inventory for this bin and product already exists");
                    ViewData["BinID"] = new SelectList(_context.Bins, "BinID", "BinName", inventory.BinID);
                    ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription", inventory.ProductID);
                    return View(inventory);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BinID"] = new SelectList(_context.Bins, "BinID", "BinName", inventory.BinID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription", inventory.ProductID);
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            ViewData["BinID"] = new SelectList(_context.Bins, "BinID", "BinName", inventory.BinID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription", inventory.ProductID);
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventoryID,QTY,BinID,ProductID")] Inventory inventory)
        {
            if (id != inventory.InventoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.InventoryID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // Exception for invalid Inventory entry
                catch (DbUpdateException ex)
                {
                    // send message to view
                    ModelState.AddModelError("BinID", "An inventory for this bin and product already exists");
                    ViewData["BinID"] = new SelectList(_context.Bins, "BinID", "BinName", inventory.BinID);
                    ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription", inventory.ProductID);
                    return View(inventory);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BinID"] = new SelectList(_context.Bins, "BinID", "BinName", inventory.BinID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription", inventory.ProductID);
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventories
                .Include(i => i.Bin)
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.InventoryID == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventories.Any(e => e.InventoryID == id);
        }
    }
}
