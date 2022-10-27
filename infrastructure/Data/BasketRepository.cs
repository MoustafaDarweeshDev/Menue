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
    public class BasketRepository : IBasketRepository
    {
        private readonly PostContext _context;

        public BasketRepository(PostContext context)
        {
            _context = context;
        }


        public async Task<Basket> AddItemToBasket(int basketId, Item itemToAdd)
        {
            var basket = _context.Baskets.Include(b=>b.OrderItems).FirstOrDefault(b => b.Id == basketId);
            if (basket == null) return null;
            basket.OrderItems.Add(itemToAdd);
            await _context.SaveChangesAsync();
            return basket;
        }

        public async Task<int> Createbasket()
        {
            var basket =new Basket();
            _context.Baskets.Add(basket);
            await _context.SaveChangesAsync();
            return basket.Id;
        }

        public async Task<Basket> DeleteItemFromBasket(int basketId , int itemId)
        {
            var basket = _context.Baskets.Include(s => s.OrderItems).FirstOrDefault(orderItems => orderItems.Id == basketId);
            if (basket == null) return null;
            var item =_context.Items.Find(itemId);
            basket.OrderItems.Remove(item);
            await _context.SaveChangesAsync();
            return basket;
        }

        public Basket GetBasket(int id)
        {
            var basket = _context.Baskets.Include(s=>s.OrderItems).FirstOrDefault(orderItems => orderItems.Id == id);
            if (basket == null) return null;

            return basket;
        }
    }
}
