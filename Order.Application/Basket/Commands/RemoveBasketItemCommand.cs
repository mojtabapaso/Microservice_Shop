using Sheard.ApiResult;
using Sheard.Mediator;

namespace Order.Application.Basket.Commands;

public record RemoveBasketItemCommand(long UserId, long ProductId) : ICommand<ServiceResult>;
