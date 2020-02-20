using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Stripe;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        private ShopContext context;

        public CartController(ShopContext context)
        {
            this.context = context;
        }
        public IActionResult dashboard()
        {
            string user = HttpContext.Session.GetString("user");

            if (user == null)
            {
                
                return Redirect("/");
            }

            var s = (from item in context.Cart select item.Product.Price * item.Quantity).Sum();
            ViewBag.total = s;
            return View();
        }
        [HttpPost]
        public IActionResult UpdateQuantity([FromBody] VueCart vc)
        {
            Cart c = (from item in context.Cart
                      where item.UserId == vc.user_id && 
                      item.ProductId==vc.product
                      select item).FirstOrDefault();
            c.Quantity = vc.quantity;
            if (c.Quantity == 0)
            {
                context.Cart.Remove(c);
            }
            this.context.SaveChanges();
            return Json(vc);
        }
        [HttpPost]
        public IActionResult Remove([FromBody] VueCart vc)
        {

            Cart c = (from item in context.Cart
                      where item.UserId == vc.user_id &&
                      item.ProductId == vc.product
                      select item).FirstOrDefault();
            //c.Quantity = vc.quantity;
            context.Cart.Remove(c);
            this.context.SaveChanges();
            return Json(vc);

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail
                //SourceToken = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                Customer = customer.Id
            });

            return View();
        }
        public IActionResult GetCartData()
        {
            string user = HttpContext.Session.GetString("user");
            int id = int.Parse(user);
            var items = (from item in context.Cart
                             where item.UserId == id
                             select new
                             {
                                 Product = (from k in context.Products
                                            where k.Id == item.ProductId
                                            select k).FirstOrDefault(),
                                 quantity = item.Quantity,
                                 user = user

                             }).ToList();
            return Json(items);

        }
      
    }
}