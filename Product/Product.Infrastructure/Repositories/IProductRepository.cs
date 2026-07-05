using Microservice.Core.Repository;

namespace Product.Infrastructure.Repositories;

public interface IProductRepository : IGenericRepository<Domian.Entities.Product>
{
    Task<Domian.Entities.Product> FindByRowIdAsync(Guid RowId);
}
