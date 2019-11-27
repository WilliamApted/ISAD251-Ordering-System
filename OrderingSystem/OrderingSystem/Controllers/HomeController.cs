using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Models.Database;

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

        
        public IActionResult UpdateOrder(int itemId)
        {
            //Response.Cookies.Delete("Basket");

            /*
            if (Request.Cookies["Basket"] != null)
            {
                Set("Basket", itemId.ToString());
            }
            else 
            {
                Set("Basket", "1");
            }
            */
            Set("Basket", itemId.ToString());


            return PartialView("/Views/Shared/Menu/_Basket.cshtml", itemId.ToString());
        }

















        /// <summary>  
        /// set the cookie  
        /// </summary>  
        /// <param name="key">key (unique indentifier)</param>  
        /// <param name="value">value to store in cookie object</param>  
        public void Set(string key, string value)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append(key, value, option);
        }
    }
}