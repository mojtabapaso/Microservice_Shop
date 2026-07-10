using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Order.Infrastructure.Repositories;

namespace Order.Application.Orders.Queries;

public sealed class GetMyOrdersQueryHandler(IOrderRepository orderRepository) : IQueryHandler<GetMyOrdersQuery, ServiceResult<List<Domain.Entities.Order>>>
{
    public async Task<ServiceResult<List<Domain.Entities.Order>>> Handle(GetMyOrdersQuery request, CancellationToken cancellationToken)
    {
        var dto = request.GetMyOrdersDto;
        var orders = await orderRepository.GetByUserIdAsync(dto.UserId, dto.Page, dto.PageSize);
        return ServiceResult<List<Domain.Entities.Order>>.Success(orders);
    }
}