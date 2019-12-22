using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.Models.Database;
using OrderingSystem.Models.Database.Entities;

namespace OrderingSystem.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CategoryController(DatabaseContext context)
        {
            _context = context;
        }

        // GET : /Category/
        //Returns the list of all placed orders.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetOrders()
        {
            using (_context)
            {
                return await _context.Category.ToListAsync();
            }
        }
    }
}