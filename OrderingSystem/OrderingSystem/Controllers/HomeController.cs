using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Models.Database;

namespace OrderingSystem.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View(GetMenuItems());
        }

        public LinkedList<Item> GetMenuItems() 
        {
            LinkedList<Item> items = new LinkedList<Item>();

            items.AddLast(new Item() { Name = "Example Item", Description = "Example description", Price = 2.99M, Category = 1 });
            items.AddLast(new Item() { Name = "Example Item 2", Description = "Example description 2", Price = 2.99M, Category = 1 });

            return items;       
        }

    }
}