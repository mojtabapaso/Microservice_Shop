using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RabbitMQ.Client;

namespace Microservice.Core.HealthChecks;

public static class RabbitMqHealthCheck
{
    public static IHealthChecksBuilder AddRabbitMqHealthCheck(this IHealthChecksBuilder builder, IConfiguration configuration)
    {
        var factory = new ConnectionFactory
        {
            HostName = configuration["RabbitMq:Host"]!,
            Port = configuration.GetValue("RabbitMq:Port", 5672),
            UserName = configuration["RabbitMq:Username"]!,
            Password = configuration["RabbitMq:Password"]!,
            VirtualHost = configuration["RabbitMq:VirtualHost"] ?? "/"
        };

        return builder.AddCheck("RabbitMq", new RabbitMqHealthChecker(factory));
    }
    private sealed class RabbitMqHealthChecker(ConnectionFactory factory) : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,CancellationToken cancellationToken = default)
        {
            return HealthCheckResult.Healthy();
            //try
            //{
            //    await using var connection = await factory.CreateConnectionAsync(cancellationToken);

            //    return connection.IsOpen
            //        ? HealthCheckResult.Healthy()
            //        : HealthCheckResult.Unhealthy();
            //}
            //catch (Exception ex)
            //{
            //    return HealthCheckResult.Unhealthy(ex.Message, ex);
            //}
        }
    }
}