using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Order.Infrastructure.Repositories;

namespace Order.Application.Orders.Queries;

public sealed class GetOrderQueryHandler(IOrderRepository orderRepository) : IQueryHandler<GetOrderQuery, ServiceResult<Domain.Entities.Order>>
{
    public async Task<ServiceResult<Domain.Entities.Order>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.FindByIdAsync(request.GetOrderDto.OrderId);

        if (order is null)
            return ServiceResult<Domain.Entities.Order>.Failure();

        return ServiceResult<Domain.Entities.Order>.Success(order);
    }
}
