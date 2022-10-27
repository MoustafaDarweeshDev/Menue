using core.Entities;
using core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSTest.ModelViews;

namespace infrastructure.Data
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly PostContext _context;

        public ItemsRepository(PostContext context)
        {
            _context = context;
        }

        public async Task<Item> AddItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> DeleteItemById(int id)
        {
            var item =_context.Items.FirstOrDefault(o=>o.Id == id);
            if (item == null) return null;
                _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<IReadOnlyList<PricesWithItemsDTO>> GetAllPricesAsync()
        {
            List<PricesWithItemsDTO> itemsToShowDtos = new List<PricesWithItemsDTO>();
            var prices = await _context.Prices.ToListAsync();

            foreach (var price in prices)
            {
                var item = _context.Items.Find(price.ItemId);

                PricesWithItemsDTO itemWithPrice = new PricesWithItemsDTO() { 
                    Id = item.Id,
                    Name = item.Name,
                    ImageUrl=item.ImageUrl,
                    Size=price.SizeName,
                    Price = price.SizePrice,
                };
                itemsToShowDtos.Add(itemWithPrice);
            }

            return itemsToShowDtos;

        }

        public async Task<IReadOnlyList<Item>> GetItemsAsync()
        {
            return await _context.Items.Include(o => o.Prices).ToListAsync();
        }







        //public async Task<IReadOnlyList<PricesWithItemsDTO>> GetAllPricesAsync()
        //{
        //    List<PricesWithItemsDTO> s = new List<PricesWithItemsDTO>();
        //    var  prices = await _context.Prices.ToListAsync();

        //    foreach (var pr in prices)
        //    {
        //        var item = _context.Items.Find(pr.itemId);

        //        PricesWithItemsDTO priceDto = new PricesWithItemsDTO()
        //        {
        //            Price = pr,
        //            Item = item
        //         };
        //        s.Add(priceDto);
        //    }


        //    return s;
        //}

       
    }
}
