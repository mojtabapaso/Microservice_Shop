using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Order.Infrastructure.Repositories;

namespace Order.Application.Orders.Commands;

public sealed class ConfirmOrderCommandHandler(IOrderRepository orderRepository) : ICommandHandler<ConfirmOrderCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.FindByIdAsync(request.ConfirmOrderDto.OrderId);

        if (order is null)
            return ServiceResult.NotFound();
        order.Confirm();
        return ServiceResult.Success();
    }
}
