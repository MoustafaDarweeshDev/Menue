using core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Interfaces
{
    public interface IOrdersRepository
    {
        public Task<IReadOnlyList<Order>> GetAllOrdersAsync();
        public Task<Order> CreateOrder(Order orderToCreate);
        public Task<Order> PlaceOrder(int baskketId , string cusName,string custPhone);
    }
}
