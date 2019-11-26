using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Models.Database;
using OrderingSystem.Models.UserAccount;

namespace OrderingSystem.Controllers
{
    public class HomeController : Controller
    {

        private readonly DatabaseContext _context;
        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(GetMenuItems());
        }


        public List<Item> GetMenuItems() 
        {
            //Create database query - Only get available menu items.
            var menuQuery = from item in _context.Item where item.Available == true select item;
            List<Item> items = menuQuery.ToList();
            return items;       
        }


    }
}