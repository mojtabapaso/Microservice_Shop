using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Order.Application.Orders.DTOs;

namespace Order.Application.Orders.Queries;

public sealed record GetMyOrdersQuery(GetMyOrdersDto GetMyOrdersDto): IQuery<ServiceResult<List<Domain.Entities.Order>>>;
