using Microservice.Core.EventPublisher;
using Microservice.Core.Interfaces;
using Microservice.Core.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Core.Extensions;

public static class ScanningExtensions
{
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
}

public static class AddEventPublisherExtensions
{
    public static IServiceCollection AddEventPublisher(this IServiceCollection services)
    {
        services.AddScoped<IEventContext, EventContext>();
        services.AddScoped<IEventPublisher, EventPublisher.EventPublisher>();
        return services;
    }
}
