using MediatR;

namespace Microservice.Core.Mediator;

public interface IQueryHandler<IQuery, TResponse> : IRequestHandler<IQuery, TResponse> where IQuery : IQuery<TResponse>;
