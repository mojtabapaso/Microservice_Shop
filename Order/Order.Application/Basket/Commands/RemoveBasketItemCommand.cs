using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;

namespace Order.Application.Basket.Commands;

public record RemoveBasketItemCommand(long UserId, Guid ProductId) : ICommand<ServiceResult>;
