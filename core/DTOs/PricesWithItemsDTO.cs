using core.Entities;

namespace POSTest.ModelViews
{
    public class PricesWithItemsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        
    }
}
