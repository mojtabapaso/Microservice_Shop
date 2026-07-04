using Microservice.Core.Interfaces;
using Microservice.Core.Repository;
using Product.Infrastructure.Configurations;

namespace Product.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Domian.Entities.Product, DbContextProduct>, IScopedDependency, IProductRepository
{
    private DbContextProduct context;
    public ProductRepository(DbContextProduct context) : base(context)
    {
        this.context = context; 
    }
}
