using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;

namespace Microservice.Core.HealthChecks;

public sealed class MongoDbHealthCheck(string connectionString) : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var client = new MongoClient(connectionString);
            await client.ListDatabaseNamesAsync(cancellationToken);
            return HealthCheckResult.Healthy();
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy(ex.Message, ex);
        }
    }
}
