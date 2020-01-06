using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.Models.Database;
using OrderingSystem.Models.Database.Entities;
using OrderingSystem.Models.Ordering;
using OrderingSystem.SharedFunctions;

namespace OrderingSystem.Controllers
{
    public class OrderController : Controller
    {

        private readonly DatabaseContext _context;
        public OrderController(DatabaseContext context)
        {
            _context = context;
        }

        //Loads the Index page - Shows the cafe menu.
        public IActionResult Index()
        {
            using (_context)
            {
                //Getting the full list of menu items
                ViewData["menu"] = GetMenuItems();

                //Checking if an order is being edited, or just a new order.
                ViewData["editing"] = Basket.IsEditing(Request.Cookies["EditOrder"]);

                //Gets the list of items in the basket
                ViewData["basket"] = new Basket(Request.Cookies["Basket"]).GetItemDetails(_context);
            }
            return View();
        }

        //Gets all available menu items
        public List<Item> GetMenuItems(int category = 0)
        {
            //Gets all available items.
            var menuQuery = from item in _context.Item where item.Available == true select item;
            List<Item> items;
            if (category != 0)
            {
                //Returns items in the select category.
                items = menuQuery.Where(item => item.Category.Equals(category)).ToList();
            }
            else
            {
                //Returns items in all categorys
                items = menuQuery.ToList();
            }
            return items;
        }

        //Will return a partial view to update the menu with filters applied to categories. 
        [ValidateAntiForgeryToken]
        public IActionResult FilterMenu(int category) 
        {
            return PartialView("/Views/Shared/Menu/_menu.cshtml", GetMenuItems(category));
        }

        //Returns the view order page
        public IActionResult ViewOrder() 
        {
            return View();
        }

        //Called to view an orders detail - then make changes or cancel.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ViewOrder(OrderManage orderDetail)
        {
            using (_context)
            {
                if (ModelState.IsValid)
                {
                    //Checking the order exists and information is correct.
                    orderDetail.GetOrder(_context);
                    if (orderDetail.order != null)
                    {
                        //Gets all the details on the order to display.
                        ViewData["OrderDetails"] = orderDetail.GetItemDetails(_context);
                        ViewData["OrderName"] = orderDetail.order.Name;
                        ViewData["OrderNumber"] = orderDetail.order.Id;
                        ViewData["OrderDate"] = orderDetail.order.dateTime;
                        return View("ViewOrderList");
                    }
                    //Add modelstate error here.
                    ModelState.AddModelError(string.Empty, "Details do not match any order.");
                }
                return View();
            }
        }

        //Used to begin editing an order.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditOrder(int orderId, string name)
        {
            using (_context)
            {
                OrderManage order = new OrderManage(orderId, name);
             
                //Ensure order exists
                order.GetOrder(_context);
                if (order.order != null)
                {
                    //Sets up the basket with the list of items in the order.
                    Basket basket = new Basket();
                    basket.SetToOrder(_context, order.OrderId);
                    CookieManager.SetCookie("Basket", basket.GetSerialised(), Response);

                    //Set EditOrder Cookie: Holding the order id and name used to later save any changes.
                    CookieManager.SetCookie("EditOrder", order.GetSerialised(), Response);
                }

                return RedirectToAction("Index");
            }
        }

        //Saves the changes to the order being edited.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEditOrder()
        {
            using (_context)
            {
                //Gets the order details from the cookie.
                OrderManage order = new OrderManage(Request.Cookies["EditOrder"]);
                //Then saves the changes made to the order.
                order.SaveEdit(new Basket(Request.Cookies["Basket"]), _context);

                //Then clears the cookies used for editing an order.
                CookieManager.RemoveCookie("Basket", Response);
                CookieManager.RemoveCookie("EditOrder", Response);

                return View("EditOrderComplete");
            }
        }

        //Cancels the desired order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CancelOrder(int orderId, string name)
        {
            using (_context)
            {
                //Deletes the order if the orderId and name match the order.
                OrderManage order = new OrderManage(orderId, name);
                order.CancelOrder(_context);

                //Show order canceled message
                return View("CancelOrderComplete");
            }
        }

        //Loads order comfirmation page
        public IActionResult ConfirmOrder()
        {
            using (_context)
            {
                //Gets details on all items in basket, used to display on confirm page.
                Basket basket = new Basket(Request.Cookies["Basket"]);
                ViewData["basket"] = basket.GetItemDetails(_context);
                ViewData["total"] = basket.GetTotal(_context);
                return View();
            }
        }

        //Confirms the order.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmOrder(OrderConfirmation order)
        {
            using (_context)
            {
                Basket basket = new Basket(Request.Cookies["Basket"]);
                if (ModelState.IsValid)
                {
                    //Gets the items from the basket cookie, then calling newOrder method.
                    int orderId = order.NewOrder(basket, _context);
                    CookieManager.RemoveCookie("Basket", Response);

                    //Then returns order no/name information to display confirmation.
                    ViewData["OrderNo"] = orderId;
                    ViewData["OrderName"] = order.Name;

                    return View("OrderComplete");
                }

                //Returning the confirm order view again with errors showing.
                ViewData["basket"] = basket.GetItemDetails(_context);
                ViewData["total"] = basket.GetTotal(_context);
                return View();
            }
        }
    }
}