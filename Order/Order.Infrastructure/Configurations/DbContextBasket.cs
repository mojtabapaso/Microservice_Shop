using Microservice.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;

namespace Order.Infrastructure.Configurations;

public class DbContextBasket : BaseDbContext
{
    public DbContextBasket(DbContextOptions<DbContextBasket> options) : base(options)
    {
    }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new BasketConfiguration());
        builder.ApplyConfiguration(new BasketItemConfiguration());
    }

}
