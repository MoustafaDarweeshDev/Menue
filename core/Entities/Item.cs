using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Entities
{
    public class Item:BaseEntity
    {
       

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public List<Price> Prices { get; set; }=new List<Price>();
    }
}
