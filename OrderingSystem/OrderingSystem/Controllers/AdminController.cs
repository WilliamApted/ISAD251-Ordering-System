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
using OrderingSystem.Models.Database.Entities;

namespace OrderingSystem.Controllers
{
    public class AdminController : Controller
    {
        
        private readonly DatabaseContext _context;
        public AdminController(DatabaseContext context)
        {
            _context = context;
        }

        //Index page - Shows login page Or list of items.
        public IActionResult Index() 
        {
            //Check the user is logged in.
            if (User.Identity.IsAuthenticated)
            {
                //Gets all the menu items
                using (_context)
                {
                    var menuQuery = from item in _context.Item select item;
                    List<Item> items = menuQuery.ToList();
                    ViewData["menu"] = items;

                    return View();
                }
            }
            else 
            {
                //Shows the login page if not logged in.
                return View("Login");
            }
        }

        //Loads the login view.
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        //Loads the view showing a list of placed orders.
        [Authorize]
        public IActionResult ViewOrders()
        {
            //Get list of all orders, with basic details - ID, Name, Table Number, Time...
            using (_context)
            {
                //Gets all the orders (sorted by newest first.)
                var orderQuery = from order in _context.Order select order;
                orderQuery = orderQuery.OrderByDescending(orderby => orderby.Id);
                List<Order> items = orderQuery.ToList();

                return View(items);
            }
        }

        //Gets the list of items associated with an order.
        [Authorize]
        [HttpPost]
        public IActionResult ViewOrderDetails(int orderId)
        {
            using (_context)
            {
                int example = orderId;
                var orderQuery = from orderSearch in _context.OrderItem where orderSearch.OrderId == orderId select orderSearch;
                List<OrderItem> orderItems = orderQuery.ToList();

                //Returning a partial view for the order list page.
                return PartialView("/Views/Shared/Admin/_OrderDetails.cshtml", GetItemList(orderItems));
            }
        }

        //Returns all the details for items.
        public List<ItemDetailsModel> GetItemList(List<OrderItem> orderItems)
        {
            List<ItemDetailsModel> itemDetails = new List<ItemDetailsModel>();

            foreach (OrderItem item in orderItems)
            {
                //For each item, gets the name, price, image etc.
                var menuQuery = from tempitem in _context.Item where tempitem.Id == item.ItemId select tempitem;
                Item items = menuQuery.First();
                itemDetails.Add(new ItemDetailsModel() { ItemId = item.ItemId, Name = items.Name, Quantity = item.Quantity, Price = items.Price, ImgUrl = items.ImageUrl });
            }
            return itemDetails;
        }

        //Loads the page to edit an item.
        [Authorize]
        public IActionResult EditItemRequest(int itemId)
        {
            using (_context)
            {
                Item item = _context.Item.First(select => select.Id == itemId);
                return View("EditItem", new ItemModel(item));
            }
        }

        //Submits an update to an item.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditItem(ItemModel editItem)
        {
            using (_context)
            {
                if (ModelState.IsValid)
                {
                    editItem.Update(_context);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
        }

        //Loads page to add a new item.
        [Authorize]
        public IActionResult AddItem() 
        {
            return View();
        }

        //Saves a new item.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddItem(ItemModel newItem) 
        {
            using (_context)
            {
                if (ModelState.IsValid)
                {
                    newItem.Add(_context);
                    return View();
                }
                else
                {
                    return View();
                }
            }
        }

        //Checks the password and authenticates the admin.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                //Just uses a hardcoded password for this case. 
                if (loginModel.Password == "example") 
                {
                    //Creates the admin session
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, "Admin") };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index");

                } else {
                    //Returns an invalid password error
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        //Signs out the admin then returns back to the index.
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Admin");
        }
    }
}