using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Order.Application.Orders.DTOs;

namespace Order.Application.Orders.Queries;

public sealed record GetOrderQuery(GetOrderDto GetOrderDto) : IQuery<ServiceResult<Domain.Entities.Order>>;
