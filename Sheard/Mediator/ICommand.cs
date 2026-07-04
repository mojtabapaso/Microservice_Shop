using MediatR;

namespace Sheard.Mediator;

public interface ICommand<TResponse> : IRequest<TResponse>;
