using Bogus;
using Core.Intrastructure;
using ProductService.Domain;

namespace ProductService.Infrastructure
{
    public class FakeProductRepository : FakeEntityRepository<int, Product>, IProductRepository
    {
        public FakeProductRepository(Faker<Product> faker) : base(faker)
        {
        }
    }
}