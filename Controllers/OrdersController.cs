using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.DAL;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagement.Controllers
{
    public class OrdersController : Controller
    {
        private readonly InventoryManagementContext _context;

        public OrdersController(InventoryManagementContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Get order with nested data
            var order = await _context.Orders
                .Include(m => m.OrderLines)
                .ThenInclude(ol => ol.Product)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription");
            return View(Order.Create());
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,OrderNumber,DateOrdered,CustomerName,CustomerAddress,OrderLines")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                foreach (var line in order.OrderLines)
                {
                    line.OrderID = order.OrderID;
                    _context.OrderLines.Add(line);
                }

                try
                {
                    await _context.SaveChangesAsync();
                }
                // Exception for duplicate order IDs
                catch (DbUpdateException ex)
                {
                    // send message to view
                    ModelState.AddModelError("OrderID", "An order with this ID already exists");
                    ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription");
                    return View(order);
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription");
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
         
            var order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderID == id);
            
            if (order == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription");
            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,OrderNumber,DateOrdered,CustomerName,CustomerAddress,OrderLines")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingOrder = _context.Orders
                    .Where(o => o.OrderID == order.OrderID)
                    .Include(o => o.OrderLines)
                    .FirstOrDefault();

                for (var i = 0; i < order.OrderLines.Count; i++)
                {
                    if (order.OrderLines[i] == null)
                    {
                        order.OrderLines.Remove(order.OrderLines[i]);
                    }
                }

                existingOrder.OrderLines = order.OrderLines;
                _context.Entry(existingOrder).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // Catching duplicate OrderID exception
                catch (DbUpdateException ex)
                {
                    // send message to view
                    ModelState.AddModelError("OrderID", "An order with this ID already exists");
                    ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription");
                    return View(order);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription");
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Get order with nested data
            var order = await _context.Orders
                .Include(m => m.OrderLines)
                .ThenInclude(ol => ol.Product)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Serves partial view for adding OrderLine entries in Create and Edit Views
        public ActionResult OrderLineRow()
        {
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription");
            return PartialView("OrderLine");
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
