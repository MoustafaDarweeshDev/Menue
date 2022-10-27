using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Entities
{
    public class Order:BaseEntity
    {
        public string CustomerName{ get; set; }
        public string CustomerPhone{ get; set; }
        public decimal Total{ get; set; }
        public DateTime OrderDate { get; set; }= DateTime.Now;
        public List<Item> Items { get; set; }
    }

}
