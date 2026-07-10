using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Order.Infrastructure.Repositories;

namespace Order.Application.Orders.Commands;

public sealed class CreateOrderCommandHandler(IOrderRepository orderRepository) : ICommandHandler<CreateOrderCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var dto = request.CreateOrderDto;
        var order = new Domain.Entities.Order(dto.BasketId,dto.UserId,dto.Description);

        await orderRepository.AddAsync(order);
        return ServiceResult.Success();
    }
}
