using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.Models.API;
using OrderingSystem.Models.Database;
using OrderingSystem.Models.Ordering;

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

        // GET : /Order/
        //Returns the list of all placed orders.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            using (_context)
            {
                return await _context.Order.ToListAsync();
            }
        }

        // GET : /Order/{order id}
        //Returns details on a specific order.
        [HttpGet("{id}")]
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

        // POST : /Order/{name associate with order}
        //Creates a new order
        [HttpPost("{name}")]
        public async Task<IActionResult> AddOrder(String name, ApiOrder order)
        {
            order.order.Name = name;
            ApiOrder example = order;
            
            //Create the order...
            
            return NotFound();
        }

        // PUT : /requests/Order/
        //Updates an existing order.
        [HttpPut()]
        public async Task<IActionResult> UpdateOrder(ApiOrder order)
        {
            //Update the order here...

            
            return NotFound();
        }

        // DELETE : /requests/Order/
        //Deletes an order.
        [HttpDelete("{id}/{name}")]
        public async Task<IActionResult> DeleteOrder(int id, string name)
        {
            using (_context)
            {
                //Deletes the order if the orderId and name match the order.
                OrderManage order = new OrderManage(id, name);
                if (order.CancelOrder(_context))
                    return Ok();
            }
            return BadRequest();
        }
    }
}