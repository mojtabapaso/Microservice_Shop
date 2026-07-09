using MassTransit;
using Microservice.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Product.Infrastructure.Configurations;

public class DbContextProduct : BaseDbContext 
{
    public DbContextProduct(DbContextOptions<DbContextProduct> options) : base(options)
    {
    }
    public DbSet<Domain.Entities.Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ProductConfiguration());

        builder.AddInboxStateEntity();
        builder.AddOutboxMessageEntity();
        builder.AddOutboxStateEntity();

        builder.ApplyConfigurationsFromAssembly(typeof(DbContextProduct).Assembly);
    }
}
