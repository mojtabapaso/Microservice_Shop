using Microservice.Core.EventPublisher;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Core.Extensions;

public static class AddEventPublisherExtensions
{
    public static IServiceCollection AddEventPublisher(this IServiceCollection services)
    {
        services.AddScoped<IEventContext, EventContext>();
        services.AddScoped<IEventPublisher, EventPublisher.EventPublisher>();
        return services;
    }
}
