using Microservice.Core.Interfaces;
using Microservice.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Order.Infrastructure.Configurations;

namespace Order.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Domain.Entities.Order, DbContextBasket>, IScopedDependency, IOrderRepository
{
    DbContextBasket context;

    public OrderRepository(DbContextBasket context) : base(context)
    {
        this.context = context;
    }

    public async Task<List<Domain.Entities.Order>> GetAllAsync(int page, int pageSize)
    {
        return await _entity.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }
    public async Task<List<Domain.Entities.Order>> GetByUserIdAsync(Guid userId, int page, int pageSize)
    {
        return await _entity.Where(o => o.UserId == userId).OrderByDescending(o => o.CreatedAt)
            .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }
}