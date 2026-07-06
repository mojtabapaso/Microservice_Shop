using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Microservice.Core.Extensions;

public static class MediatorExtensions
{
    public static IServiceCollection AddApplicationMediator(this IServiceCollection services, Assembly assembly)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
        });
        return services;
    }
}
