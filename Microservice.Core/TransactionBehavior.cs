using MassTransit.Contracts;
using MediatR;
using Microservice.Core.EventPublisher;
using Microservice.Core.Interfaces;
using Microservice.Core.Mediator;

namespace Microservice.Core;

public class TransactionBehavior<TRequest, TResponse>(IUnitOfWork unitOfWork,
    IEventContext eventContext,IEventPublisher eventPublisher) : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is not ICommand<TResponse>)
            return await next();
        try
        {
            await unitOfWork.BeginTransactionAsync(cancellationToken);
            var response = await next();
            await unitOfWork.SaveChangesAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
            //raise event message brocker TODO splelate later
            foreach (var @event in eventContext.Events)
            {
                await eventPublisher.PublishAsync(@event, cancellationToken);
            }

            eventContext.Clear();
            return response;
        }
        catch
        {
            await unitOfWork.RollbackAsync(cancellationToken);
            throw;
        }
    }
}