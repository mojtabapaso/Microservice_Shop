using Sheard.ApiResult;
using Sheard.Mediator;

namespace Order.Application.Basket.Commands;

public record AddItemToBasketCommand(long UserId, long ProductId, int Quantity, decimal UunitPrice) : ICommand<ServiceResult>;
/*
 unitPriceke
نگفته شده بود توی تسک اش
 */