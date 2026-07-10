using Microservice.Core.Repository;

namespace Order.Infrastructure.Repositories;

public interface IOrderRepository :IGenericRepository<Domain.Entities.Order>
{
    Task<List<Domain.Entities.Order>> GetAllAsync(int Page, int PageSize);
    Task<List<Domain.Entities.Order>> GetByUserIdAsync(Guid userId, int page, int pageSize);
}
