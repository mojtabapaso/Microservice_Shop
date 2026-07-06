using Microservice.Core.Repository;

namespace Product.Infrastructure.Repositories;

public interface IProductRepository : IGenericRepository<Domain.Entities.Product>
{
    Task<Domain.Entities.Product> FindByRowIdAsync(Guid RowId);
}
