using Microservice.Core.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Core.Extensions;



public static class HealthCheckExtensions
{
    public static IHealthChecksBuilder AddSqlServerHealthCheck(this IHealthChecksBuilder builder, string connectionString, string name = "SQL Server")
    {
        return builder.AddCheck(name, new SqlServerHealthCheck(connectionString));
    }

    public static IHealthChecksBuilder AddMongoDbHealthCheck(this IHealthChecksBuilder builder, string connectionString, string name = "MongoDB")
    {
        return builder.AddCheck(name, new MongoDbHealthCheck(connectionString));
    }

    public static IHealthChecksBuilder AddRedisHealthCheck(this IHealthChecksBuilder builder, string connectionString, string name = "Redis")
    {
        return builder.AddCheck(name, new RedisHealthCheck(connectionString));
    }


    public static IHealthChecksBuilder AddDefaultHealthChecks(this IServiceCollection services)
    {
        return services.AddHealthChecks();
    }
}

