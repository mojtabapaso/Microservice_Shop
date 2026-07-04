using MediatR;
using Microservice.Core.Interfaces;

namespace Microservice.Core.Mediator;

public class QueryDispatcher(IMediator mediator) :IScopedDependency, IQueryDispatcher
{
    public Task<TResponse> Dispatch<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
    {
        return mediator.Send(query, cancellationToken);
    }
}
