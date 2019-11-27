using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Models.Database;
using OrderingSystem.Models.Items;

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

        
        public IActionResult UpdateOrderAsync(int itemId)
        {
            string cookieValue = Request.Cookies["Basket"];
            List<CookieBasketModel> basket;

            //Check if list exists in cookie, if it does, get it, then add or remove from list.
            if (cookieValue != null && cookieValue != "")
            {
                //Cookie exists, so get the data 
                basket = JsonSerializer.Deserialize<List<CookieBasketModel>>(cookieValue);
                basket = AddItemToBasket(basket, itemId);
            }
            else 
            {
                //Doesnt exist, so create new list
                basket = new List<CookieBasketModel>();
                basket = AddItemToBasket(basket, itemId);
            }
            cookieValue = JsonSerializer.Serialize(basket);

            //Response.Cookies.Delete("Basket");

            Set("Basket", cookieValue);
            List<BasketItemModel> basketModel = GetBasketItemList(basket);
            return PartialView("/Views/Shared/Menu/_Basket.cshtml", basketModel);
        }

        /// <summary>
        /// Gets the basketItem Models to display the current order basket.
        /// </summary>
        /// <param name="cookieBasket">List of items in the basket.</param>
        /// <returns>List of BasketItem Models.</returns>
        public List<BasketItemModel> GetBasketItemList(List<CookieBasketModel> cookieBasket) 
        {
            List<BasketItemModel> basketItems = new List<BasketItemModel>();

            foreach (CookieBasketModel item in cookieBasket) 
            {
                //Perhaps use stored procedure to get this...
                var menuQuery = from tempitem in _context.Item where tempitem.Id == item.ItemId select tempitem;
                Item items = menuQuery.First();
                //Adds the Basket Item model to the list
                basketItems.Add(new BasketItemModel() { Name = items.Name, Quantity = item.Quantity, Price = items.Price, ImgUrl = items.ImageUrl });
            }

            return basketItems;
        }

        /// <summary>
        /// Adds an item to the basket list.
        /// </summary>
        /// <param name="basket">Current basket list.</param>
        /// <param name="itemId">Item to add.</param>
        /// <returns>Updated basket list.</returns>
        public List<CookieBasketModel> AddItemToBasket(List<CookieBasketModel> basket, int itemId) 
        {
            //Check if item exists, if it does, add quantity.
            foreach (CookieBasketModel item in basket)
            {
                if (item.ItemId == itemId)
                {
                    item.Quantity++;
                    return basket;
                }
            }
            //If it doesnt exist, add it here.
            basket.Add(new CookieBasketModel() { ItemId = itemId, Quantity = 1 });
            return basket;
        }

        /// <summary>  
        /// set the cookie  
        /// </summary>  
        /// <param name="key">Cookie identifier.</param>  
        /// <param name="value">String to store in the cookie.</param>  
        public void Set(string key, string value)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append(key, value, option);
        }




    }
}