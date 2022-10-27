using core.Entities;
using core.Interfaces;
using infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTest.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository _orderRepo;

        public OrdersController(IOrdersRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IReadOnlyList<Order>> GetAllOrders()
        {
            return await _orderRepo.GetAllOrdersAsync();
        }

        //[HttpPost]
        //public async Task<Order> PlaceOrder([FromBody]Order orderToCreate)
        //{
        //    return await _orderRepo.CreateOrder(orderToCreate);
        //}

        [HttpPost]
        public async Task<Order> PlaceOrder(int basketId,string custName,string cusPhone)
        {
            return await _orderRepo.PlaceOrder(basketId,custName,cusPhone);
        }
    }
}
