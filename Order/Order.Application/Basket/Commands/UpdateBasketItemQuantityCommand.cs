using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;

namespace Order.Application.Basket.Commands;

public record UpdateBasketItemQuantityCommand(long UserId, Guid ProductId, int NewQuantity) : ICommand<ServiceResult>;