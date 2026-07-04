namespace Microservice.Core.Mediator;

public interface ICommandDispatcher
{
    Task<TResponse> Dispatch<TResponse>(ICommand<TResponse> command,CancellationToken cancellationToken = default);
}
