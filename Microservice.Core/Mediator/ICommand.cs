using MediatR;

namespace Microservice.Core.Mediator;

public interface ICommand<TResponse> : IRequest<TResponse>;
