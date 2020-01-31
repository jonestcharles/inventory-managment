using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.DAL;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    /// <summary>
    /// HTTP Controller for Bins Model
    /// </summary>
    public class BinsController : Controller
    {
        private readonly InventoryManagementContext _context;

        public BinsController(InventoryManagementContext context)
        {
            _context = context;
        }

        // GET: Bins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bins.ToListAsync());
        }

        // GET: Bins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bin = await _context.Bins
                .FirstOrDefaultAsync(m => m.BinID == id);
            if (bin == null)
            {
                return NotFound();
            }

            return View(bin);
        }

        // GET: Bins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BinID,BinName")] Bin bin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bin);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    // send message to view
                    ModelState.AddModelError("BinName", "A bin with this name already exists");
                    return View(bin);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(bin);
        }

        // GET: Bins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bin = await _context.Bins.FindAsync(id);
            if (bin == null)
            {
                return NotFound();
            }
            return View(bin);
        }

        // POST: Bins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BinID,BinName")] Bin bin)
        {
            if (id != bin.BinID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinExists(bin.BinID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException ex)
                {
                    // send message to view
                    ModelState.AddModelError("BinName", "A bin with this name already exists");
                    return View(bin);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bin);
        }

        // GET: Bins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bin = await _context.Bins
                .FirstOrDefaultAsync(m => m.BinID == id);
            if (bin == null)
            {
                return NotFound();
            }

            return View(bin);
        }

        // POST: Bins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bin = await _context.Bins.FindAsync(id);
            _context.Bins.Remove(bin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinExists(int id)
        {
            return _context.Bins.Any(e => e.BinID == id);
        }
    }
}
