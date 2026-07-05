using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Product.Infrastructure.Configurations;

public static class MongoConfiguration
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<MongoOptions>(configuration.GetSection(MongoOptions.SectionName));
        return services;
    }
}
