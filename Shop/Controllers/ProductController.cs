using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        
        private ShopContext context;
        public ProductController(ShopContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Products product)
        {
            string error = "";
            Users user = (from item in context.Users
                          where item.Id == product.UserId
                          select item).FirstOrDefault();

            var products = context.Products.Where(m => m.Id == product.Id).ToList();
            if (string.IsNullOrEmpty(product.Name) || string.IsNullOrEmpty(product.Description))
            {
                error = "Lracreq hamapatasxan dasht@";
            }
            else if (product.Count < 0 || product.Price < 1)
            {
                error = "Lracreq hamapatasxan dasht@";
            }



            if (error == "")
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
            else
            {

                TempData["error"] = error;
                return Redirect("/Product/Add");

            }



            return Redirect("/User/Profile");
        }
        public IActionResult AddToCart(int id)
        {
            string user = HttpContext.Session.GetString("user");
            if(user == null)
            {
                return Redirect("/");
            }
            Cart elm = (from item in context.Cart where item.ProductId == id && item.UserId == int.Parse(user) select item).FirstOrDefault();
            if(elm != null)
            {
                return Redirect("/Product/All");

            }
            Cart c = new Cart();
            c.ProductId = id;
            c.Quantity = 1;
            c.UserId = int.Parse(HttpContext.Session.GetString("user"));
            context.Cart.Add(c);
            context.SaveChanges();
            return Redirect("/Cart/dashboard");
        }
        
        public IActionResult All()
        {
            string id = HttpContext.Session.Id;
                
            if (!String.IsNullOrEmpty(id))
            {
               ViewBag.product = context.Products.ToList();
            }
            else
            {
                return Redirect("/Product/Add");
            }
            return View();
        }
        public IActionResult Details(int id)
        {
            Products p = (from item in context.Products where item.Id == id select item).FirstOrDefault();
            ViewBag.product = p;
            return View();
        }
       
        
        
    }
}