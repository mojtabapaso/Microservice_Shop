using Microservice.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

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
    }
}
