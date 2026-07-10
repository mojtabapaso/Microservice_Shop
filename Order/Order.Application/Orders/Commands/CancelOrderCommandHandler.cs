using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Order.Infrastructure.Repositories;

namespace Order.Application.Orders.Commands;

public sealed class CancelOrderCommandHandler(IOrderRepository orderRepository) : ICommandHandler<CancelOrderCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var dto = request.CancelOrderDto;

        var order = await orderRepository.FindByIdAsync(dto.OrderId);

        if (order is null)
            return ServiceResult.NotFound();
        if (order.UserId != dto.UserId)
            return ServiceResult.Failure("You are not allowed to cancel this order.");
        order.Cancel(dto.Reason);
        return ServiceResult.Success();
    }
}
