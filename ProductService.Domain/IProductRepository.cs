using Core.Domain;

namespace ProductService.Domain
{
    public interface IProductRepository : IEntityRepository<int, Product>
    {

    }
}