using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Order.Application.Orders.DTOs;

namespace Order.Application.Orders.Commands;

public sealed record ChangeOrderStatusCommand(ChangeOrderStatusDto ChangeOrderStatusDto) : ICommand<ServiceResult>;
