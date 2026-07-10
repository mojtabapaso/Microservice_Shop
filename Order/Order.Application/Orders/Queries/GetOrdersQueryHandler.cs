using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Order.Infrastructure.Repositories;

namespace Order.Application.Orders.Queries;

public sealed class GetOrdersQueryHandler(IOrderRepository orderRepository): IQueryHandler<GetOrdersQuery, ServiceResult<List<Domain.Entities.Order>>>
{
    public async Task<ServiceResult<List<Domain.Entities.Order>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var dto = request.GetOrdersDto;

        var orders = await orderRepository.GetAllAsync(dto.Page, dto.PageSize);
         
        return ServiceResult<List<Domain.Entities.Order>>.Success(orders);
    }
}
