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
               
        // GET : /requests/menu/
        //Returns the all the menu items.
        [HttpGet("menu/")]
        public async Task<ActionResult<IEnumerable<Item>>> GetMenu()
        {
            using (_context)
            {
                return await _context.Item.ToListAsync();
            }
        }

        // GET : /requests/menu/{menu item id}
        //Returns the details of a single menu item.
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

        // GET : /requests/Order/
        //Returns the list of all placed orders.
        [HttpGet("Order/")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            using (_context)
            {
                return await _context.Order.ToListAsync();
            }
        }

        // GET : /requests/Order/{order id}
        //Returns details on a specific order.
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

        // POST : /requests/Order/
        //Creates a new order
        [HttpPost("Order")]
        public async Task<ActionResult<Category>> AddOrder(ApiOrder apiOrder)
        {
            _context.Order.Add(apiOrder.order);
            _context.OrderItem.AddRange(apiOrder.items);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Order", new { id = apiOrder.order.Id }, apiOrder);
        }

        // PUT : /requests/Order/
        //Updates an existing order.
        [HttpPut("Order")]
        public async Task<ActionResult<Category>> UpdateOrder(ApiOrder apiOrder)
        {
            _context.Order.Add(apiOrder.order);
            _context.OrderItem.AddRange(apiOrder.items);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Order", new { id = apiOrder.order.Id }, apiOrder);
        }

        // DELETE : /requests/Order/
        //Deletes an order.
        [HttpDelete("Order/{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
        
            return NotFound();
        }


    }
}
