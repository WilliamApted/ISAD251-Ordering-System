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
            ViewData["menu"] = GetMenuItems();

            ViewData["basket"] = GetBasketItemList(GetBasketList());
            
            return View();
        }

        public IActionResult ViewOrder() 
        {
            return View();
        }
        public IActionResult ViewOrderList()
        {
            return View();
        }

        public List<CookieBasketModel> GetBasketList() 
        {
            string cookieValue = Request.Cookies["Basket"];
            //Check if list exists in cookie, if it does, get it, then add or remove from list.
            if (cookieValue != null && cookieValue != "")
            {
                //Cookie exists, so get the data 
                return JsonSerializer.Deserialize<List<CookieBasketModel>>(cookieValue);
            }
            else
            {
                //Doesnt exist, so create new list
                return new List<CookieBasketModel>();
            }
        }

        public decimal GetBasketTotal(List<CookieBasketModel> basket) 
        {
            decimal total = 0;
            foreach (CookieBasketModel basketItem in basket) 
            {
                var menuQuery = from item in _context.Item where item.Id == basketItem.ItemId select item;
                total = total + basketItem.Quantity * menuQuery.First().Price;
            }
            return total;
        }


        [HttpPost]
        public async Task<IActionResult> ConfirmOrder(ConfirmOrderModel order)
        {
            if (ModelState.IsValid)
            {
                //Get item list with quantities - Check valid entries, with them available.
                List<CookieBasketModel> basket = GetBasketList();

                //Create new order, add name, table number etc
                
                //Move to stored procedures where possible
                if (basket.Count > 0) 
                {
                    Order orderEntry = new Order() { dateTime = DateTime.Now, Name = order.Name, Table = (int)order.TableNumber };
                    _context.Order.Add(orderEntry);
                    _context.SaveChanges();

                    foreach(CookieBasketModel item in basket) 
                    {
                        _context.OrderItem.Add(new OrderItem() { ItemId = item.ItemId, Quantity = item.Quantity, OrderId = orderEntry.Id });
                    }
                    _context.SaveChanges();
                    Set("Basket", "");

                    ViewData["OrderNo"] = orderEntry.Id;
                    ViewData["OrderName"] = orderEntry.Name;
                    
                    return View("OrderComplete");
                }

                    //Add new orderItems 

                return RedirectToAction("Index", "Home");
            }
            else {
                List<CookieBasketModel> basket = GetBasketList();
                ViewData["basket"] = GetBasketItemList(basket);
                ViewData["total"] = GetBasketTotal(basket);
                return View();
            }
        }

        public IActionResult ConfirmOrder() 
        {
            List<CookieBasketModel> basket = GetBasketList();
            ViewData["basket"] = GetBasketItemList(basket);
            ViewData["total"] = GetBasketTotal(basket);
            return View();
        }


        public List<Item> GetMenuItems() 
        {
            //Create database query - Only get available menu items.
            var menuQuery = from item in _context.Item where item.Available == true select item;
            List<Item> items = menuQuery.ToList();
            return items;       
        }

        public IActionResult RemoveFromBasket(int itemId)
        {
            List<CookieBasketModel> basket = JsonSerializer.Deserialize<List<CookieBasketModel>>(Request.Cookies["Basket"]);

            foreach (CookieBasketModel item in basket) 
            {
                if (item.ItemId == itemId) {
                    item.Quantity--;
                    if (item.Quantity < 1) 
                    {
                        basket.Remove(item);
                        break;
                    }               
                }
            }
            Set("Basket", JsonSerializer.Serialize(basket));
            List<BasketItemModel> basketModel = GetBasketItemList(basket);


            return PartialView("/Views/Shared/Menu/_Basket.cshtml", basketModel);
        }

        public IActionResult AddToBasket(int itemId)
        {
            string cookieValue = Request.Cookies["Basket"];
            List<CookieBasketModel> basket;

            //Check if list exists in cookie, if it does, get it, then add or remove from list.
            if (cookieValue != null && cookieValue != "")
            {
                //Cookie exists, so get the data 
                basket = JsonSerializer.Deserialize<List<CookieBasketModel>>(cookieValue);
            } else {
                //Doesnt exist, so create new list
                basket = new List<CookieBasketModel>();
            }
            basket = AddItemToBasket(basket, itemId);

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
                basketItems.Add(new BasketItemModel() { ItemId = item.ItemId, Name = items.Name, Quantity = item.Quantity, Price = items.Price, ImgUrl = items.ImageUrl });
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