using Microsoft.Extensions.Diagnostics.HealthChecks;
using StackExchange.Redis;

namespace Microservice.Core.HealthChecks;

public sealed class RedisHealthCheck(string connectionString) : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var connection = await ConnectionMultiplexer.ConnectAsync(connectionString);

            return connection.IsConnected ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy();
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy(ex.Message, ex);
        }
    }
}
