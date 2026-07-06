using MassTransit;
using MediatR;
using Microservice.Core.EventPublisher;
using Microservice.Core.Interfaces;
using Microservice.Core.Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System.Reflection;


namespace Microservice.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationMediator(this IServiceCollection services, Assembly assembly)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
        });
        return services;

    }
    public static IServiceCollection AddSqlServer<TContext>(this IServiceCollection services, IConfiguration configuration) where TContext : DbContext, IUnitOfWork
    {
        services.AddDbContext<TContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
        services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<TContext>());

        //services.AddScoped<IUnitOfWork, TContext>(); => wrong Dotn use it
        return services;
    }
    public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration,
        Action<IBusRegistrationConfigurator> configure)
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
    public static IServiceCollection AddPipelineBehaviors(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
        return services;
    }
    public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConnectionMultiplexer>(_ =>
        {
            var connection = configuration.GetConnectionString("Redis");
            return ConnectionMultiplexer.Connect(connection!);
        });

        return services;
    }
    public static IServiceCollection AddDependencyScanning<TAssembly>(this IServiceCollection services)
    {
        services.Scan(scan => scan
          .FromAssemblies(
            typeof(SharedAbstractionAssemblyReference).Assembly,
            typeof(TAssembly).Assembly)
            .AddClasses(c => c.AssignableTo<IScopedDependency>())
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(c => c.AssignableTo<ITransientDependency>())
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            .AddClasses(c => c.AssignableTo<ISingletonDependency>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime());
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();
        return services;
    }
    public static IServiceCollection AddEventPublisher(this IServiceCollection services)
    {
        services.AddScoped<IEventContext, EventContext>();
        services.AddScoped<IEventPublisher, EventPublisher.EventPublisher>();
        return services;
    }
}