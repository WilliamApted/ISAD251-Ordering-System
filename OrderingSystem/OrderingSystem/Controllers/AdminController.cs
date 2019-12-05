using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Models.Database;
using OrderingSystem.Models.AdminAccount;
using OrderingSystem.Models.Ordering;
using Microsoft.AspNetCore.Authorization;

namespace OrderingSystem.Controllers
{
    public class AdminController : Controller
    {
        
        private readonly DatabaseContext _context;
        public AdminController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index() 
        {
            if (User.Identity.IsAuthenticated)
            {
                //Get all items
                var menuQuery = from item in _context.Item select item;
                List<Item> items = menuQuery.ToList();
                ViewData["menu"] = items;

                return View();
            }
            else 
            {
                //Show login here
                return View("Login");
            }
        }

        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [Authorize]
        public IActionResult ViewOrders()
        {
            //Get list of all orders, basic details - ID, Name, Table Number, Time...
            var orderQuery = from order in _context.Order select order;
            orderQuery = orderQuery.OrderByDescending(orderby => orderby.Id);
            List<Order> items = orderQuery.ToList();

            return View(items);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ViewOrderDetails(int orderId)
        {
            int example = orderId;
            var orderQuery = from orderSearch in _context.OrderItem where orderSearch.OrderId == orderId select orderSearch;
            List<OrderItem> orderItems = orderQuery.ToList();
                                             
            return PartialView("/Views/Shared/Admin/_OrderDetails.cshtml", GetItemList(orderItems));
        }

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


        [Authorize]
        public IActionResult EditItemRequest(int itemId)
        {
            Item item = _context.Item.First(select => select.Id == itemId);

            return View("EditItem", new ItemModel(item));
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditItem(ItemModel editItem)
        {
            if (ModelState.IsValid)
            {
                Item item = _context.Item.First(select => select.Id == editItem.Id);
                item.UpdateModel(editItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else 
            {
                return View();
            }

        }

        [Authorize]
        public IActionResult AddItem() 
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddItem(ItemModel newItem) 
        {
            if (ModelState.IsValid)
            {
                Item item = new Item(newItem);
                _context.Item.Add(item);
                _context.SaveChanges();
                //Return some feedback of success
                return View();
            }
            else 
            {
                return View();
            }       
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                if (loginModel.Password == "examplePassword") 
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, "Admin") };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index");

                } else {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Admin");
        }
    }
}