using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.Models.API;
using OrderingSystem.Models.Database;

namespace OrderingSystem.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public RequestsController(DatabaseContext context)
        {
            _context = context;
        }
               
        // GET: api/Menu
        [HttpGet("menu/")]
        public async Task<ActionResult<IEnumerable<Item>>> GetMenu()
        {
            using (_context)
            {
                return await _context.Item.ToListAsync();
            }
        }

        [HttpGet("menu/{id}")]
        public async Task<ActionResult<Item>> Get(int id)
        {
            using (_context)
            {
                var item = await _context.Item.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                return item;
            }
        }

        // GET: api/Order
        [HttpGet("Order/")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            using (_context)
            {
                return await _context.Order.ToListAsync();
            }
        }

        // GET: api/Order/5
        [HttpGet("Order/{id}")]
        public async Task<ActionResult<ApiOrder>> GetOrder(int id)
        {
            ApiOrder apiOrder = new ApiOrder();

            using (_context)
            {

                apiOrder.order = await _context.Order.FindAsync(id);
                var orderQuery = from item in _context.OrderItem where item.OrderId == id select item;
                apiOrder.items = orderQuery.ToList();
            }

            if (apiOrder.order == null)
            {
                return NotFound();
            }

            return apiOrder;
        }

        [HttpPost("Order")]
        public async Task<ActionResult<Category>> PostOrder(ApiOrder apiOrder)
        {
            _context.Order.Add(apiOrder.order);
            _context.OrderItem.AddRange(apiOrder.items);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Order", new { id = apiOrder.order.Id }, apiOrder);
        }

        // DELETE: api/Categories/5
        [HttpDelete("Order/{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }


    }
}
