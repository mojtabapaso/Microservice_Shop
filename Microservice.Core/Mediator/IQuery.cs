using MediatR;

namespace Microservice.Core.Mediator;


public interface IQuery<TResponse> : IRequest<TResponse>;