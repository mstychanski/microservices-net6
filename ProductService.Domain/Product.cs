using Core.Domain;

namespace ProductService.Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }

    }
}