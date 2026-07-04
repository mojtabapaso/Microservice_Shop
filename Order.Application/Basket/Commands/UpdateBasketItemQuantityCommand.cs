using Sheard.ApiResult;
using Sheard.Mediator;

namespace Order.Application.Basket.Commands;

public record UpdateBasketItemQuantityCommand(long UserId, long ProductId, int NewQuantity) : ICommand<ServiceResult>;