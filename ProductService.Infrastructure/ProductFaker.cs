using Bogus;
using ProductService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Description, f => f.Commerce.ProductDescription());
            RuleFor(p => p.Color, f => f.Commerce.Color());
            RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()));
        }
    }
}
