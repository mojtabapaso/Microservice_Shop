using Product.Domain.Documents;

namespace Product.Infrastructure.Repositories;

public interface IProductMongoRepository
{
    Task UpsertAsync(ProductDocument product, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<ProductDocument?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<ProductDocument>> GetAllAsync(CancellationToken cancellationToken);
}
