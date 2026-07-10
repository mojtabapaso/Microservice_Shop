using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Order.Application.Basket.DTOs;

namespace Order.Application.Basket.Queries;

public record GetOrCreateBasketQuery(GetBasketDTO GetBasketDTO) : IQuery<ServiceResult<BasketDTO>>;
