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


        public IActionResult Index()
        {

            return View();
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
        [HttpPut]
        public async Task<Item> UpdateItem([FromBody] Item itemToEdit,int id)
        {
            await _itemsRepository.UpdateItem(itemToEdit,id);
            return itemToEdit;
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

        [HttpGet]
        public Task<int> CreateBasket()
        {
            return this._basketRepo.Createbasket();
        }

        [HttpPost]
        public async Task<Basket> addItemToBasket(int id , int itemId,int priceId)
        {
            return  await _basketRepo.AddItemToBasket(id, itemId, priceId);
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


        [HttpGet]
        public async Task<IReadOnlyList<PricesWithItemsDTO>> GetAllPrices()
        {
            return await _itemsRepository.GetAllPricesAsync();
        }


    }
}
