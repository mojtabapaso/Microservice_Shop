using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Core.Extensions;

public static class MessagingExtensions
{
    public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration, Action<IBusRegistrationConfigurator> configure)
    {
        services.AddMassTransit(x =>
        {
            configure(x);
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration["RabbitMq:Host"], h =>
                {
                    h.Username(configuration["RabbitMq:Username"]!);
                    h.Password(configuration["RabbitMq:Password"]!);
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
    public static IServiceCollection AddRabbitMq<TDbContext>(this IServiceCollection services, IConfiguration configuration, Action<IBusRegistrationConfigurator> configure)
        where TDbContext : DbContext
    {
        services.AddMassTransit(x =>
        {
            configure(x);
            x.AddEntityFrameworkOutbox<TDbContext>(o =>
            {
                o.UseSqlServer();

                o.UseBusOutbox();
            });
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration["RabbitMq:Host"], h =>
                {
                    h.Username(configuration["RabbitMq:Username"]!);
                    h.Password(configuration["RabbitMq:Password"]!);
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
