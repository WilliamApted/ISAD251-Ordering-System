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
            return View();
        }

        [Authorize]
        public IActionResult EditItem(int itemId)
        {
            Item item = _context.Item.First(select => select.Id == itemId);

            return View(new ItemModel(item));
        }

        [Authorize]
        [HttpPost]
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
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Admin");
        }
    }
}