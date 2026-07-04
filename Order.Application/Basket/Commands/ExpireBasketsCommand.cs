using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;

namespace Order.Application.Basket.Commands;

public record ExpireBasketsCommand : ICommand<ServiceResult>;

