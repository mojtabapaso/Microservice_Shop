namespace Microservice.Core.Mediator;

public interface IQueryDispatcher
{
    Task<TResponse> Dispatch<TResponse>(IQuery<TResponse> command, CancellationToken cancellationToken = default);
}
