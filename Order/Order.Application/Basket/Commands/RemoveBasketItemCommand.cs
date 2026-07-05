using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;

namespace Order.Application.Basket.Commands;

public record RemoveBasketItemCommand(long UserId, long ProductId) : ICommand<ServiceResult>;
