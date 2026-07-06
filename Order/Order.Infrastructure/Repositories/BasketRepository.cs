using MassTransit.Initializers;
using Microservice.Core.Interfaces;
using Microservice.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;
using Order.Domain.Enums;
using Order.Infrastructure.Configurations;

namespace Order.Infrastructure.Repositories;

public class BasketRepository : GenericRepository<Basket, DbContextBasket>, IScopedDependency, IBasketRepository
{
    private readonly DbContextBasket context;

    
    public BasketRepository(DbContextBasket context) : base(context)
    {
        this.context = context;
    }
    public DbContextBasket Context => context;
    public async Task<Basket?> GetActiveBasketWithItemsByUserId(long userId)
    {
        var res = await context.Baskets
         .Include(x => x.Items)
         .FirstOrDefaultAsync(x =>
             x.UserId == userId &&
             x.Status == BasketStatus.Active);
        return res;
    }
    public async Task<Basket?> GetBasketWithAllItemsByUserIdAsync(long userId)
    {
        var res = await context.Baskets
         .Include(x => x.Items)
         .FirstOrDefaultAsync(x =>
             x.UserId == userId);
        return res;
    }
    public async Task<Basket?> GetBasketByUserIdAsync(long userId)
    {
        var res = await context.Baskets.FirstOrDefaultAsync(x => x.UserId == userId);
        return res;
    }
    public async Task<long> GetActiveBasketIdByUserId(long userId)
    {
        var res = await context.Baskets
         .FirstOrDefaultAsync(x =>
             x.UserId == userId &&
             x.Status == BasketStatus.Active).Select(x => x.Id);
        return res;
    }
    public async Task<List<Basket>> GetExpiredBasketsAsync()
    {
        var threshold = DateTime.UtcNow.AddMinutes(-30);

        var baskets = await context.Baskets
            .Where(x => x.Status == BasketStatus.Active && x.LastUpdatedAt <= threshold)
            .ToListAsync();
        return baskets;
    }

    public async Task<List<Basket>> GetBasketsByProductIdAsync(Guid productId,CancellationToken cancellationToken)
    {
        return await context.Baskets.Include(x => x.Items).Where(x => x.Items.Any(i => i.ProductId == productId))
            .ToListAsync(cancellationToken);
    }
}
