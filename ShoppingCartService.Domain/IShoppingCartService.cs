namespace ShoppingCartService.Domain
{
    public interface IShoppingCartService
    {
        Task Add(Guid shoppingCartId, Detail detail);
        Task Remove(Guid shoppingCartId, int productId);
    }
}