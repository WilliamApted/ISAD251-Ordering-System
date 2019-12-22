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
    public class MenuController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MenuController(DatabaseContext context)
        {
            _context = context;
        }

        // GET : /menu/
        //Returns the all the menu items.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetMenu()
        {
            using (_context)
            {
                return await _context.Item.ToListAsync();
            }
        }

        // GET : /menu/{menu item id}
        //Returns the details of a single menu item.
        [HttpGet("{id}")]
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


    }
}