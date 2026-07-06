using Microservice.Core.Caching;
using Microservice.Core.Interfaces;
using StackExchange.Redis;

namespace Order.Infrastructure.Cache;

public class BasketCacheService : CacheService , IScopedDependency, IBasketCacheService
{
    public BasketCacheService(IConnectionMultiplexer redis) : base(redis)
    {
    }
}
