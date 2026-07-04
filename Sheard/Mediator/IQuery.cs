using MediatR;

namespace Sheard.Mediator;


public interface IQuery<TResponse> : IRequest<TResponse>;