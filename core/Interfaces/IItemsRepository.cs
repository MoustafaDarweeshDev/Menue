using core.Entities;
using POSTest.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Interfaces
{
    public interface IItemsRepository
    {
        Task<IReadOnlyList<Item>> GetItemsAsync();
        Task<Item> DeleteItemById(int id);
        Task<Item> AddItem(Item item);
        Task<IReadOnlyList<PricesWithItemsDTO>> GetAllPricesAsync();

    }
}
