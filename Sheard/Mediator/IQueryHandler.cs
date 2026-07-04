using MediatR;

namespace Sheard.Mediator;

public interface IQueryHandler<IQuery, TResponse> : IRequestHandler<IQuery, TResponse> where IQuery : IQuery<TResponse>;
