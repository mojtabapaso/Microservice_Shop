using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;

namespace Order.Application.Basket.Commands;

public record ClearBasketCommand(long UserId) : ICommand<ServiceResult>;
