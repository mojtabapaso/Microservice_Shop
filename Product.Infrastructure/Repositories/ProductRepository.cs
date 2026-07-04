using Product.Infrastructure.Configurations;
using Sheard.Interfaces;
using Sheard.Repository;

namespace Product.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Domian.Entities.Product, DbContextProduct>, IScopedDependency, IProductRepository
{
    private DbContextProduct context;
    public ProductRepository(DbContextProduct context) : base(context)
    {
        this.context = context; 
    }
}
