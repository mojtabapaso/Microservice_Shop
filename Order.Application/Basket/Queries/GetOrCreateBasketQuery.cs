using Order.Application.Basket.DTOs;
using Sheard.ApiResult;
using Sheard.Mediator;

namespace Order.Application.Basket.Queries;

public record GetOrCreateBasketQuery(long userId) : IQuery<ServiceResult<BasketDTO>>;
