using Sheard.Interfaces;
using Sheard.Repository;
using StackExchange.Redis;

namespace Order.Infrastructure.Services.Cache;

public class BasketCacheService : CacheService , IScopedDependency, IBasketCacheService
{
    public BasketCacheService(IConnectionMultiplexer redis) : base(redis)
    {
    }
}
