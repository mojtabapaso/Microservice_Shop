using MediatR;
using Microservice.Core.PipelineBehavior;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Core.Extensions;

public static class PipelineExtensions
{
    public static IServiceCollection AddPipelineBehaviors(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
        return services;
    }
}
