using MediatR;
using Microservice.Core.Interfaces;

namespace Microservice.Core.Mediator;

public class CommandDispatcher(IMediator mediator) : IScopedDependency, ICommandDispatcher
{
    public Task<TResponse> Dispatch<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
    {
        return mediator.Send(command, cancellationToken);
    }
}
