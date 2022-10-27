using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Entities
{
    public class Basket:BaseEntity
    {
        public List<Item> OrderItems { get; set; }=new List<Item>() { };

      
    }
}
