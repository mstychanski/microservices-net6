namespace ShoppingCartService.Domain
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public IEnumerable<Detail> Details { get; set; }
    }
}