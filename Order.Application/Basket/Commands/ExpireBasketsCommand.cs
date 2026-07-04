using Sheard.ApiResult;
using Sheard.Mediator;

namespace Order.Application.Basket.Commands;

public record ExpireBasketsCommand : ICommand<ServiceResult>;

