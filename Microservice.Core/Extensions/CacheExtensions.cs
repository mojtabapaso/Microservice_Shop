using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Microservice.Core.Extensions;

public static class CacheExtensions
{
    public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConnectionMultiplexer>(_ =>
        {
            var connection = configuration.GetConnectionString("Redis");
            return ConnectionMultiplexer.Connect(connection!);
        });

        return services;
    }
}
