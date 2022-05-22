using ShoppingCartService.Domain;
using StackExchange.Redis;

namespace ShoppingCartService.Infrastructure
{
    // dotnet add package StackExchange.Redis
    public class RedisShoppingCartService : IShoppingCartService
    {
        private readonly IDatabase db;

        public RedisShoppingCartService(IConnectionMultiplexer connectionMultiplexer)
        {
            db = connectionMultiplexer.GetDatabase();
        }

        public async Task Add(Guid shoppingCartId, Detail detail)
        {
            RedisKey key = $"cart:{shoppingCartId}:{detail.ProductId}";

            if(await db.KeyExistsAsync(key)) 
            {
                await db.HashIncrementAsync(key, "Quantity", detail.Quantity);
            }
            else
            {
                HashEntry[] entries = Map(detail);
            }
        }

        private HashEntry[] Map(Detail detail) => new HashEntry[]
        {
            new(nameof(Detail.Quantity), detail.Quantity.ToString()),
            new (nameof(Detail.UnitPrice), detail.UnitPrice.ToString()),
        };

        public async Task Remove(Guid shoppingCartId, int productId)
        {
            RedisKey key = $"cart:{shoppingCartId}:{productId}";

            var quantity = int.Parse(db.HashGet(key, "Quantity"));

            if (quantity == 1)
            {
                await db.KeyDeleteAsync(key);
            }
            else
            {
                await db.HashIncrementAsync(key, "Quantity", -1);
            }
        }
    }
}