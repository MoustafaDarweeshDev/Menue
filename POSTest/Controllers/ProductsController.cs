using core.Entities;
using infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTest.Controllers
{
    public class ProductsController : Controller
    {
        private readonly PostContext db;

        public ProductsController(PostContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {

            if (Request.Cookies["Basket_Id"] != null)
            {
                 var basketId = int.Parse(Request.Cookies["Basket_Id"]);
                 var basket =  db.Baskets.Include(o=>o.OrderItems).FirstOrDefault(o=>o.Id == basketId);
                decimal total = 0;
                foreach (var item in basket.OrderItems)
                {
                    total += item.Price;
                }
                 ViewData["Basket"] = basket.OrderItems;
                 ViewData["BasketTotal"] = total;
            }


            var model = db.Items.Include(o => o.Prices).ToList();  
            return View(model);
        }
        public async Task<IActionResult> AddToCart(int id)
        {
            Item cardItem = db.Items.Find(id) ;
            if (Request.Cookies["Basket_Id"] == null) { 
                var basket = new Basket();
                var response = HttpContext.Response;
                basket.OrderItems.Add(cardItem);
                db.Baskets.Add(basket);
                await db.SaveChangesAsync();
                response.Cookies.Append("Basket_Id", basket.Id.ToString());
            }
            else
            {
                var basketId = Request.Cookies["Basket_Id"];
                var basket =  db.Baskets.Find(int.Parse(basketId));
                basket.OrderItems.Add(cardItem);
                await db.SaveChangesAsync();

            }



            return RedirectToAction("Index" , db.Items.Include(o => o.Prices).ToList());
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var itemToRemove =  db.Items.Find(id);
            var basketId = Request.Cookies["Basket_Id"];
            var basket = db.Baskets.Find(int.Parse(basketId));
            basket.OrderItems.Remove(itemToRemove);
            await db.SaveChangesAsync();

            ViewData["Basket"] = basket.OrderItems;

            return RedirectToAction("Index", db.Items.Include(o => o.Prices).ToList());

        }
    }
}
