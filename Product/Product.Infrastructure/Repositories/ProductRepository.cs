using Microservice.Core.Interfaces;
using Microservice.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Product.Infrastructure.Configurations;

namespace Product.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Domian.Entities.Product, DbContextProduct>, IScopedDependency, IProductRepository
{
    private DbContextProduct context;
    public ProductRepository(DbContextProduct context) : base(context)
    {
        this.context = context;
    }

    public async Task<Domian.Entities.Product> FindByRowIdAsync(Guid RowId)
    {
        var result = await _entity.Where(x => x.RowId == RowId).FirstOrDefaultAsync();
        return result;
            
    }
}
