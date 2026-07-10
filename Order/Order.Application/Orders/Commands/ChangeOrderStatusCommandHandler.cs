using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Order.Domain.Enums;
using Order.Infrastructure.Repositories;

namespace Order.Application.Orders.Commands;

public sealed class ChangeOrderStatusCommandHandler(IOrderRepository orderRepository) : ICommandHandler<ChangeOrderStatusCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
    {
        var dto = request.ChangeOrderStatusDto;

        var order = await orderRepository.FindByIdAsync(dto.OrderId);

        if (order is null)
            return ServiceResult.NotFound();

        switch (dto.Status)
        {
            case OrderStatus.Confirmed:
                order.Confirm();
                break;

            case OrderStatus.Processing:
                order.StartProcessing();
                break;

            case OrderStatus.Shipped:
                order.Ship();
                break;

            case OrderStatus.Delivered:
                order.Deliver();
                break;

            default:
                return ServiceResult.Failure("Invalid status.");
        }

        return ServiceResult.Success();
    }
}
