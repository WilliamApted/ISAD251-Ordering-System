using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem._Utility;
using OrderingSystem.Models.Database;
using OrderingSystem.Models.UserAccount;

namespace OrderingSystem.Controllers
{
    public class AccountController : Controller
    {

        private readonly DatabaseContext _context;
        public AccountController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel loginModel)
        {
            if (ModelState.IsValid)
            {
                //Check if email already exists
                if((from userInfo in _context.User where loginModel.Email == userInfo.Email select userInfo).Count() > 0)   
                {
                    ModelState.AddModelError(string.Empty, "Email already exists.");
                    return View();
                }

                //Creating salt, salting password then adding account record.
                string salt = AccountAuth.GenerateSalt();
                User newUser = new User() { Email = loginModel.Email, Password = AccountAuth.HashPass(salt, loginModel.Password), Salt = salt};
                _context.User.Add(newUser);
                _context.SaveChanges();

                //Now log user in...
                return await Login(new LoginModel() { Email = loginModel.Email, Password = loginModel.Password });
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
                var user = await AuthenticateUser(loginModel.Email, loginModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, "Customer"),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
           
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Index", "Home");
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

            return RedirectToAction("Index", "Home");
        }

        private async Task<UserModel> AuthenticateUser(string email, string password)
        {
            User user = (from userInfo in _context.User where email == userInfo.Email select userInfo).FirstOrDefault();

            if (user == null) return null;

            if (AccountAuth.CheckPassword(password, user.Password, user.Salt))
            {
                return new UserModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                };
            }
            else
            {
                return null;
            }
        }
    }
}