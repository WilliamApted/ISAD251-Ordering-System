using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.Models.API;
using OrderingSystem.Models.Database;
using OrderingSystem.Models.Database.Entities;
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
        public async Task<ActionResult<IEnumerable<View_OrderOverview>>> GetOrders()
        {
            using (_context)
            {
                return await _context.OrderOverview.ToListAsync();
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
                //Gets the overview of the order with the select id.
                apiOrder.order = await _context.OrderOverview.FindAsync(id);
                //Gets all items associated with the order.
                var orderQuery = from item in _context.OrderItem where item.OrderId == id select item;
                apiOrder.items = orderQuery.ToList();
            }

            if (apiOrder.order == null)
            {
                return NotFound();
            }
            //Returns the apiOrder - which includes the orderoverview and order items.
            return apiOrder;
        }

        // POST : /Order/{table number}/{name associate with order}
        //Example body: [{"itemId":4,"quantity":2},{"itemId":6,"quantity":2}]
        //Creates a new order
        [HttpPost("{table}/{name}")]
        public IActionResult AddOrder(int table, String name, List<OrderItem> items)
        {
            if (name != null && items != null)
            {
                //Creates a new order
                Order newOrder = new Order() { Name = name, Table = table, dateTime = DateTime.Now };
                using (_context)
                {
                    //Adding the new order entry to the database
                    _context.Order.Add(newOrder);
                    _context.SaveChanges();
                    //Adding all order items to the database.
                    _context.OrderItem.AddRange(items.ConvertAll(item => new OrderItem { ItemId = item.ItemId, Quantity = item.Quantity, OrderId = newOrder.Id }));
                    _context.SaveChanges();
                }
                //Respond with created.
                return StatusCode(201);
            }
            //Incorrect input parameters.
            return BadRequest();
        }

        // PUT : /requests/Order/
        //Updates an existing order.
        [HttpPut("{id}/{name}")]
        public IActionResult UpdateOrder(int id, string name, List<OrderItem> items)
        {
            using (_context)
            {
                //Checks the order exists with the parameters 
                if (_context.Order.Where(findOrder => findOrder.Id == id && findOrder.Name == name).FirstOrDefault() != null)
                {
                    //Removes item from order then adds the updated list of items.
                    SqlParameter orderParam = new SqlParameter("@query", id);
                    _context.Database.ExecuteSqlRaw("DeleteOrderItems @query", orderParam);
                    _context.OrderItem.AddRange(items.ConvertAll(item => new OrderItem { ItemId = item.ItemId, Quantity = item.Quantity, OrderId = id }));
                    _context.SaveChanges();
                    return StatusCode(201);
                }
            }
            return BadRequest();
        }

        // DELETE : /requests/Order/
        //Deletes an order.
        [HttpDelete("{id}/{name}")]
        public IActionResult DeleteOrder(int id, string name)
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