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
    public class OrderController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OrderController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return await _context.Order.ToListAsync();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiOrder>> Get(int id)
        {
            ApiOrder apiOrder = new ApiOrder();

            apiOrder.order = await _context.Order.FindAsync(id);
            var orderQuery = from item in _context.OrderItem where item.OrderId == id select item;
            apiOrder.items = orderQuery.ToList();

            if (apiOrder.order == null)
            {
                return NotFound();
            }

            return apiOrder;
        }



        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(ApiOrder apiOrder)
        {
            _context.Order.Add(apiOrder.order);
            _context.OrderItem.AddRange(apiOrder.items);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("Order", new { id = apiOrder.order.Id }, apiOrder);
        }
    }
}
