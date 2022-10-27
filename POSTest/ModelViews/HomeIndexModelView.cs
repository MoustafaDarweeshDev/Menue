using core.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace POSTest.ModelViews
{
    public class HomeIndexModelView
    {
        public List<Item> Items { get; set; }

        public Item item { get; set; }

        public IFormFile Image{ get; set; }
    }
}
