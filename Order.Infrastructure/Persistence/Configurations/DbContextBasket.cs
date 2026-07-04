using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Order.Domain.Entities;
using Sheard.Interfaces;

namespace Order.Infrastructure.Persistence.Configurations;

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
