
using core.Entities;
using core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Data
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly PostContext _context;

        public OrdersRepository(PostContext context)
        {
            _context = context;
        }


        public async Task<Order> CreateOrder(Order orderToCreate)
        {
            List<Item> itemss = new List<Item>();


            foreach (var item in orderToCreate.Items)
            {
                var itemNew = new Item()
                {
                    Id = 0,
                    Name = item.Name,
                    Price=item.Price,
                    ImageUrl = item.ImageUrl,
                    Prices = item.Prices,
                };

                itemss.Add(itemNew);

            }

            var order = new Order()
            {
                CustomerName = orderToCreate.CustomerName,
                CustomerPhone = orderToCreate.CustomerPhone,
                Total = orderToCreate.Items.Sum(o => o.Price),
                Items = itemss

            };
            _context.Orders.Add(order);

            await _context.SaveChangesAsync();
            return orderToCreate;
        }

        public async Task<IReadOnlyList<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.Include(o=>o.Items).ToListAsync();
        }

        public async Task<Order> PlaceOrder(int baskketId, string cusName, string custPhone)
        {
            var basket = await _context.Baskets.Include(o=>o.OrderItems).FirstOrDefaultAsync(o => o.Id == baskketId);
            List<Item> itemss = new List<Item>();


            foreach (var item in basket.OrderItems)
            {
                var itemNew = new Item()
                {
                    Id = 0,
                    Name = item.Name,
                    Price = item.Price,
                    ImageUrl = item.ImageUrl,
                    Prices = item.Prices,
                };

                itemss.Add(itemNew);

            }

            Order order = new Order()
            {
                CustomerName = cusName,
                CustomerPhone = custPhone,
                Total = basket.OrderItems.Sum(o => o.Price),
                Items = basket.OrderItems
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
