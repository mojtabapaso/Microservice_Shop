using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;

namespace Order.Application.Basket.Commands;

public record AddItemToBasketCommand(long UserId, Guid ProductId, int Quantity, decimal UunitPrice) : ICommand<ServiceResult>;
