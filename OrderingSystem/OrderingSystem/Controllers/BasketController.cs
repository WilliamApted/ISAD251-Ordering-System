using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Models.Database;
using OrderingSystem.Models.Ordering;
using OrderingSystem.SharedFunctions;

namespace OrderingSystem.Controllers
{
    public class BasketController : Controller
    {

        private readonly DatabaseContext _context;
        public BasketController(DatabaseContext context)
        {
            _context = context;
        }

        //Adds an item to the basket.
        [ValidateAntiForgeryToken]
        public IActionResult AddToBasket(int itemId)
        {
            //Get the value from the Basket cookie, add item, then set cookie again.
            Basket basket = new Basket(Request.Cookies["Basket"]);
            basket.AddItem(itemId);
            CookieManager.SetCookie("Basket", basket.GetSerialised(), Response);

            ViewData["editing"] = Basket.IsEditing(Request.Cookies["EditOrder"]);

            //Return partial view of basket.
            using (_context)
            {
                return PartialView("/Views/Shared/Menu/_Basket.cshtml", basket.GetItemDetails(_context));
            }
        }

        //Removes an item from the basket
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromBasket(int itemId)
        {
            //Get the value from the Basket cookie, remove item, then set cookie again.
            Basket basket = new Basket(Request.Cookies["Basket"]);
            basket.RemoveItem(itemId);
            CookieManager.SetCookie("Basket", basket.GetSerialised(), Response);

            ViewData["editing"] = Basket.IsEditing(Request.Cookies["EditOrder"]);

            //Return partial view of basket.
            using (_context)
            {
                return PartialView("/Views/Shared/Menu/_Basket.cshtml", basket.GetItemDetails(_context));
            }
        }
    }
}