using core.Entities;
using infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using POSTest.ModelViews;
using core.Interfaces;
using core;

namespace POSTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IItemsRepository _itemsRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration config;

        public HomeController(IBasketRepository basketRepo,
            IItemsRepository itemsRepository,
            IWebHostEnvironment env ,
            IConfiguration config)
        {
            _basketRepo = basketRepo;
            _itemsRepository = itemsRepository;
            _env = env;
            this.config = config;
        }
        public static HomeIndexModelView homeMV = new HomeIndexModelView();

        public IActionResult Index()
        {
            //if (Request.Cookies["Basket_Id"] != null)
            //{
            //    var basketId = int.Parse(Request.Cookies["Basket_Id"]);
            //    var basket = _db.Baskets.Include(o => o.OrderItems).FirstOrDefault(o => o.Id == basketId);
            //    decimal total = 0;
            //    foreach (var item in basket.OrderItems)
            //    {
            //        total += item.Price;
            //    }
            //    ViewData["Basket"] = basket.OrderItems;
            //    ViewData["BasketTotal"] = total;
            //}

            //homeMV.Items = _db.Items.Include(o=>o.Prices).ToList();
            //return View(homeMV);
            return View();
            //return Json(items);
        }

        [HttpGet]
        public async Task<IReadOnlyList<Item>> GetAllItems()
        {
            return  await _itemsRepository.GetItemsAsync();
        }

        [HttpDelete]
        public async Task<Item> DeleteItemById(int id)
        {
            return await _itemsRepository.DeleteItemById(id);
        }
        [HttpPost]
        public async Task<Item> Add([FromBody]Item itemToAdd)
        {
            await _itemsRepository.AddItem(itemToAdd);
            return itemToAdd;
        }

        [HttpPost]
        public Class2 Upload()
        {
            if(!Request.ContentType?.Contains("multipart/form-data")?? true)
            {
                return null;
            };
            var filesFormClient = Request.Form.Files;
            if (filesFormClient == null)return null;

            var file = filesFormClient[0];
            var allowedExtentions = new string[] { ".jpg" , ".svg",".png"};
            if(!allowedExtentions.Any(ext => file.FileName.EndsWith(ext)))
            {
                return null;
            }
            if (file.Length > 1_000_000) return null;
            string imageName = "assets/media/image/NewFolder/" + new Guid() + file.FileName;
            var path = Path.Combine(_env.WebRootPath, imageName);
            using (var streamFile = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(streamFile);
            };
            string url = config["BaseUrl"] + imageName;
            return new Class2()
            {
                Url =url
            };
        }

        //    if(Image != null)
        //    {
        //        string imageName = "assets/media/image/NewFolder/" + new Guid() + Image.FileName;
        //        var path = Path.Combine(_env.WebRootPath, imageName);
        //        using var streamFile = new FileStream(path, FileMode.Create);

        //        itemToAdd.ImageUrl = config["BaseUrl"] + imageName;
        //        Image.CopyTo(streamFile);
        //    }

        [HttpGet]
        public Task<int> CreateBasket()
        {
            return this._basketRepo.Createbasket();
        }

        [HttpPost]
        public async Task<Basket> addItemToBasket(int id , [FromBody]Item itemToAdd)
        {
            return  await _basketRepo.AddItemToBasket(id, itemToAdd);
        }

        [HttpGet]
        public  Basket getBasketById(int id)
        {
            return  this._basketRepo.GetBasket(id);
        }

        [HttpGet]
        public async Task<Basket> RemoveFromBasket(int basketId , int itemId)
        {
            return await _basketRepo.DeleteItemFromBasket(basketId, itemId);
        }




        //[HttpGet]
        //public async Task<IReadOnlyList<PricesWithItemsDTO>> GetAllPrices()
        //{
        //    return await _itemsRepository.GetAllPricesAsync();
        //}









        //public async Task<IActionResult> Add(Item itemToAdd, IFormFile Image)
        //{
        //    if(Image != null)
        //    {
        //        string imageName = "assets/media/image/NewFolder/" + new Guid() + Image.FileName;
        //        var path = Path.Combine(_env.WebRootPath, imageName);
        //        using var streamFile = new FileStream(path, FileMode.Create);
        //        itemToAdd.ImageUrl = config["BaseUrl"] + imageName;
        //        Image.CopyTo(streamFile);
        //    }

        //    var resault = _db.Items.Add(itemToAdd);

        //    if (resault !=null)
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    homeMV.Items = _db.Items.Include(o => o.Prices).ToList();

        //    return RedirectToAction("Index", homeMV);
        //}
        //public IActionResult Edit(int Id)
        //{
        //    var ItemToEdit = _db.Items.Include(o => o.Prices).ToList().FirstOrDefault(x => x.Id == Id);
        //    ViewData["itemToEdit"] = ItemToEdit;
        //    homeMV.item = ItemToEdit;
        //    return RedirectToAction("Index", homeMV);

        //}

        //public async Task<IActionResult> Delete(int Id)
        //{
        //    var itemToDelete = _db.Items.Include(o=>o.Prices).ToList().FirstOrDefault(x=>x.Id == Id);

        //    if(itemToDelete != null)
        //    {
        //        _db.Items.Remove(itemToDelete);
        //        await _db.SaveChangesAsync();
        //    }


        //    return RedirectToAction("Index", _db.Items.Include(o => o.Prices).ToList());

        //}
        //[HttpGet]
        //public string haha()
        //{
        //    return "haha";
        //}

    }
}
