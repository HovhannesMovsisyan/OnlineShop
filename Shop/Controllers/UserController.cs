using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.lib;
using Shop.Models;

namespace Shop.Controllers
{
    public class UserController : Controller
    {
        
        private ShopContext context;

        public object Session { get; private set; }

        public UserController(ShopContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]


        [HttpPost]
        public IActionResult AddUser(Users user)
        {
            string error = "";
            var users = context.Users.Where(m => m.Id == user.Id).ToList();
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Surname)
                || string.IsNullOrEmpty(user.Login))
            {
                error = "Lracreq hamapatasxan dasht@";
            }
            else if (user.Password.Length < 5 || string.IsNullOrEmpty(user.Password))
            {
                error = "password@ karch e";
            }
            else if (users.Count > 0)
            {
                error = "mutqagreq urish login";
            }


            if (error == "")
            {

                user.Password = SecurePasswordHasher.Hash(user.Password);
                context.Users.Add(user);
                context.SaveChanges();
            }
            else
            {
                TempData["error"] = error;
                return Redirect("/User/Signup");
            }



            return Redirect("/");
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Users user)
        {
            string pass = user.Password;
            user = (from item in context.Users where item.Login == user.Login 
                   select item)

                    .ToList().FirstOrDefault();
            if(user == null)
            {
                TempData["msg"] = "Login sxal en";
                return Redirect("/");
            }
            else
            {
                Users current = user;
                if (!SecurePasswordHasher.Verify(pass, current.Password))
                {
                    //TempData["msg"] = "password sxal en";
                    return Redirect("/");
                }
            }
            HttpContext.Session.SetString("user", user.Id.ToString());
            await Authenticate(user.Login);
            return Redirect("/User/Profile");
        }

        public async Task Authenticate(string logIn)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, logIn),
                new Claim(ClaimTypes.Role, "Admin")
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie");
            ClaimsPrincipal principal = new ClaimsPrincipal(id);
            await HttpContext.SignInAsync("Cookies", principal);
        }

        //[Authorize(AuthenticationSchemes = SchemesNamesConst.TokenAuthenticationDefaultScheme)]
        [Authorize(Roles = "Admin")]
        public IActionResult Profile()
        {
            string id = HttpContext.Session.GetString("user");
            if (!String.IsNullOrEmpty(id))
            {
                Users user = (from item in context.Users where item.Id == int.Parse(id) select item).FirstOrDefault();
                if(user != null)
                {
                    ViewBag.user = user;
                }
            }
            else
            {
                return Redirect("/");
            }
            return View();
        }
    }
}