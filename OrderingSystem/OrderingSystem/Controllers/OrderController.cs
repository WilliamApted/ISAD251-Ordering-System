using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.Models.Database;
using OrderingSystem.Models.Ordering;

namespace OrderingSystem.Controllers
{
    public class OrderController : Controller
    {

        private readonly DatabaseContext _context;
        public OrderController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["menu"] = GetMenuItems();

            //Should be a call to get the correct basket type...
            if(Request.Cookies["EditOrder"] != null) 
                ViewData["editing"] = true; 
            else 
                ViewData["editing"] = false;

            ViewData["basket"] = GetBasketItemList(GetBasketList());
            
            return View();
        }

        //Gets all available menu items (Need to add filters?? Also when build api??)
        public List<Item> GetMenuItems()
        {
            //Create database query - Only get available menu items.
            var menuQuery = from item in _context.Item where item.Available == true select item;
            List<Item> items = menuQuery.ToList();
            return items;
        }





        //Returns the view order page
        public IActionResult ViewOrder() 
        {
            return View();
        }
        
        //Gets Order Details, List of order items.   Checks the order exists first.
        [HttpPost]
        public IActionResult ViewOrder(ViewOrderModel viewOrderDetails)
        {
            if (ModelState.IsValid)
            {
                Order order = null;
                var orderDetailsQuery = from item in _context.Order where item.Id == viewOrderDetails.OrderNumber && item.Name == viewOrderDetails.Name select item;
                if(orderDetailsQuery.Count() > 0) order = orderDetailsQuery.First();

                if (order != null)
                {
                    List<BasketItemModel> items;

                    var orderQuery = from item in _context.OrderItem where item.OrderId == viewOrderDetails.OrderNumber select item;
                    List<OrderItem> orderItems = orderQuery.ToList();

                    ViewData["OrderDetails"] = GetItemList(orderItems);
                    ViewData["OrderName"] = order.Name;
                    ViewData["OrderNumber"] = order.Id;
                    ViewData["OrderDate"] = order.dateTime;

                    return View("ViewOrderList", viewOrderDetails);
                }
                else 
                {
                    //Incorrect name/id
                    return View();
                }
            }
            else 
            {
                return View();
            }
        }

        //Get order items, put into basket, go to menu.      Checks the order exists first.
        [HttpPost]
        public IActionResult EditOrder(int orderId, string name)
        {
            var orderDetailsQuery = from item in _context.Order where item.Id == orderId && item.Name == name select item;
            Order order = orderDetailsQuery.First();

            if (order != null)
            {
                //Return page to edit order, fill backet with previous order items. Store id of the order etc to then save changes. 
                ViewOrderModel orderModel = new ViewOrderModel() { Name = name, OrderNumber = orderId };
                SetCookie("EditOrder", JsonSerializer.Serialize(orderModel));

                SetEditBasket(orderId);
          
                //Response.Cookies.Delete("Basket");

            }
            return RedirectToAction("Index");
        }

        //Deletes all previous order items, then saves order basket.     Checks order exists first. 
        [HttpPost]
        public IActionResult SaveEditOrder()
        {
            ViewOrderModel orderInfo = JsonSerializer.Deserialize<ViewOrderModel>(Request.Cookies["EditOrder"]);


            var orderDetailsQuery = from item in _context.Order where item.Id == orderInfo.OrderNumber && item.Name == orderInfo.Name select item;
            Order order = orderDetailsQuery.First();

            if (order != null)
            {
                SqlParameter param1 = new SqlParameter("@query", orderInfo.OrderNumber);
                _context.Database.ExecuteSqlRaw("DeleteOrderItems @query", param1);

                List<CookieBasketModel> basket = GetBasketList();

                foreach (CookieBasketModel item in basket)
                {
                    _context.OrderItem.Add(new OrderItem() { ItemId = item.ItemId, Quantity = item.Quantity, OrderId = orderInfo.OrderNumber });
                }
                _context.SaveChanges();
                SetCookie("Basket", "");
                RemoveCookie("EditOrder");


            }

            return View("EditOrderComplete");


        }
     
        //Deletes the order with stored procedure.           First checks the order name/id correct and it exists.
        [HttpPost]
        public IActionResult CancelOrder(int orderId, string name)
        {
            try
            {
                var orderDetailsQuery = from item in _context.Order where item.Id == orderId && item.Name == name select item;
                Order order = orderDetailsQuery.First();

                if (order != null)
                {
                    //stored procedure to remove an order, so delete all orderItems with X id and then the order.
                    SqlParameter param1 = new SqlParameter("@query", orderId);
                    _context.Database.ExecuteSqlRaw("DeleteOrder @query", param1);
                    //return confirmation of deletion.
                    return RedirectToAction("ViewOrder");
                }
            }
            catch (Exception e)
            { //Error here? Or make sure now error 
            }
            //return delete error
            return View("Index");
        }

        //Creates new Order row, then adds OrderItems. Returns order complete.   
        [HttpPost]
        public IActionResult ConfirmOrder(ConfirmOrderModel order)
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

                    foreach (CookieBasketModel item in basket)
                    {
                        _context.OrderItem.Add(new OrderItem() { ItemId = item.ItemId, Quantity = item.Quantity, OrderId = orderEntry.Id });
                    }
                    _context.SaveChanges();
                    SetCookie("Basket", "");

                    ViewData["OrderNo"] = orderEntry.Id;
                    ViewData["OrderName"] = orderEntry.Name;

                    return View("OrderComplete");
                }

                //Add new orderItems 

                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<CookieBasketModel> basket = GetBasketList();
                ViewData["basket"] = GetBasketItemList(basket);
                ViewData["total"] = GetBasketTotal(basket);
                return View();
            }
        }

        //Loads order comfirmation page
        public IActionResult ConfirmOrder()
        {
            List<CookieBasketModel> basket = GetBasketList();
            ViewData["basket"] = GetBasketItemList(basket);
            ViewData["total"] = GetBasketTotal(basket);
            return View();
        }






        //Fills basket with items of a previous order, enabling editing of order.
        //Need to stop convertion of objects ideally...
        public void SetEditBasket(int orderId) 
        {
            var orderQuery = from item in _context.OrderItem where item.OrderId == orderId select item;
            List<OrderItem> orderItems = orderQuery.ToList();
            SetCookie("Basket", JsonSerializer.Serialize(orderItems.ConvertAll(x => new CookieBasketModel { ItemId = x.ItemId, Quantity = x.Quantity})));
        }

        //Gets basket list from cookie
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

        //Calculates the total value of items in a basket
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
           
        //Removes item from basket (Held in cookie)
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
            SetCookie("Basket", JsonSerializer.Serialize(basket));
            List<BasketItemModel> basketModel = GetBasketItemList(basket);

            //Need to put into single function
            if (Request.Cookies["EditOrder"] != null) 
            {
                return PartialView("/Views/Shared/Menu/_EditBasket.cshtml", basketModel);
            }
            return PartialView("/Views/Shared/Menu/_Basket.cshtml", basketModel);
        }

        //Adds item to the basket
        public IActionResult AddToBasket(int itemId)
        {
            List<CookieBasketModel> basket = GetBasketList();

            basket = AddItemToBasket(basket, itemId);

            SetCookie("Basket", JsonSerializer.Serialize(basket));
            List<BasketItemModel> basketModel = GetBasketItemList(basket);

            //Can be in seperate function
            if (Request.Cookies["EditOrder"] != null)
            {
                return PartialView("/Views/Shared/Menu/_EditBasket.cshtml", basketModel);
            }
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

        //Does the same as GetBasketItemList... just for the Complete Order Page etc.
        public List<BasketItemModel> GetItemList(List<OrderItem> orderItems)
        {
            List<BasketItemModel> itemDetails = new List<BasketItemModel>();

            foreach (OrderItem item in orderItems)
            {
                //Perhaps use stored procedure to get this...
                var menuQuery = from tempitem in _context.Item where tempitem.Id == item.ItemId select tempitem;
                Item items = menuQuery.First();
                //Adds the Basket Item model to the list
                itemDetails.Add(new BasketItemModel() { ItemId = item.ItemId, Name = items.Name, Quantity = item.Quantity, Price = items.Price, ImgUrl = items.ImageUrl });
            }

            return itemDetails;
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
        public void SetCookie(string key, string value)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append(key, value, option);
        }

        public void RemoveCookie(string key)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(-10);
            Response.Cookies.Append(key, "", option);
        }
    }
}