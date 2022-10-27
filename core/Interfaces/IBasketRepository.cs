using core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Interfaces
{
    public interface IBasketRepository
    {
        public Task<int> Createbasket();
        public Basket GetBasket(int id);
        public Task<Basket> AddItemToBasket(int basketId , Item itemToAdd);
        public Task<Basket> DeleteItemFromBasket(int basketId , int itemId);
    }
}
