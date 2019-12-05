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


        public IActionResult AddToBasket(int itemId)
        {
            //Get the value from the Basket cookie, add item, then set cookie again.
            BasketModel basket = new BasketModel(Request.Cookies["Basket"]);
            basket.AddItem(itemId);
            CookieManager.SetCookie("Basket", basket.GetSerialised(), Response);
            
            //Return partial view of basket.
            return PartialView("/Views/Shared/Menu/_Basket.cshtml", basket);
        }

        public IActionResult RemoveFromBasket(int itemId)
        {
            //Get the value from the Basket cookie, remove item, then set cookie again.
            BasketModel basket = new BasketModel(Request.Cookies["Basket"]);
            basket.RemoveItem(itemId);
            CookieManager.SetCookie("Basket", basket.GetSerialised(), Response);

            //Return partial view of basket.
            return PartialView("/Views/Shared/Menu/_Basket.cshtml", basket);
        }
    }
}