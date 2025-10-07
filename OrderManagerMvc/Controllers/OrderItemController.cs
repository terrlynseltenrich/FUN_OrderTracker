using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagerMvc.Data;
using OrderManagerMvc.Models;
using System.Threading.Tasks;

namespace OrderManagerMvc.Controllers

    {
    public class OrderItemController : Controller
    {

        private readonly AppDbContext _context;
        public OrderItemController(AppDbContext context)
        {
            _context = context;
        }
        // GET: OrderItem
        public async Task<IActionResult> Index()
        {
            var orderItems = await _context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Product)
                .ToListAsync();
            return View(orderItems);
        }
        // GET: OrderItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderItems == null)
            {
                return NotFound();
            }
            var orderItem = await _context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Product)
                .FirstOrDefaultAsync(m => m.Id == id); // Changed from FindAsync to FirstOrDefaultAsync for better null handling
            if (orderItem == null)
            {
                return NotFound();
            }
            return View(orderItem);
        }
        // GET: OrderItem/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Orders, "Id", "Id");
            ViewData["ProductId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Products, "Id", "Name");
            return View();
        }
        // POST: OrderItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantity,UnitPrice,OrderId,ProductId")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Orders, "Id", "Id", orderItem.OrderId);
            ViewData["ProductId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Products, "Id", "Name", orderItem.ProductId);
            return View(orderItem);
        }
        // GET: OrderItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderItems == null)
            {
                return NotFound();
            }
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Orders, "Id", "Id", orderItem.OrderId);
            ViewData["ProductId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Products, "Id", "Name", orderItem.ProductId);
            return View(orderItem);
        }
        // POST: OrderItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,UnitPrice,OrderId,ProductId")] OrderItem orderItem)
        {
            if (id != orderItem.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderItemExists(orderItem.Id))
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
            ViewData["OrderId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Orders, "Id", "Id", orderItem.OrderId);
            ViewData["ProductId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Products, "Id", "Name", orderItem.ProductId);
            return View(orderItem);
        }
        // GET: OrderItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderItems == null)
            {
                return NotFound();
            }
            var orderItem = await _context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Product)
                .FirstOrDefaultAsync(m => m.Id == id); // Changed from FindAsync to FirstOrDefaultAsync for better null handling
            if (orderItem == null)
            {
                return NotFound();
            }
            return View(orderItem);
        }
        // POST: OrderItem/Delete/5
        [HttpPost, ActionName("DeleteOrderItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOrderItemConfirmed(int id)
        {
            if (_context.OrderItems == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OrderItems'  is null.");
            }
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool OrderItemExists(int id)
        {
            return (_context.OrderItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}