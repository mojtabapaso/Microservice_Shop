using Product.Domian.Documents;

namespace Product.Infrastructure.Repositories;

public interface IProductMongoRepository
{
    Task UpsertAsync(ProductDocument product, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
