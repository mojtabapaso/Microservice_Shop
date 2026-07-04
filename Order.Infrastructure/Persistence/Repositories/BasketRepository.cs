using MassTransit.Initializers;
using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;
using Order.Domain.Enums;
using Order.Infrastructure.Persistence.Configurations;
using Sheard.Interfaces;
using Sheard.Repository;

namespace Order.Infrastructure.Persistence.Repositories;

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

    //public void RemoveBasketByUserId(long UserId)
    //{
    //    var baskets =  context.Baskets
    //    .Include(x => x.Items)
    //    .Where(x => x.UserId == UserId);
    //    context.Baskets.RemoveRange(baskets);
    //}

    //public void RemoveBasketItemByUserIdAndProductId(long UserId, long ProductId)
    //{
    //    //context.BasketItems.Include(x=>x.Id == x.ProductId )
    //    var basket = context.Baskets.Include(x => x.Items).Where(x => x.UserId == UserId && x.Items.Any(x => x.ProductId == ProductId));
    //    context.Remove(basket);
    //}
}
