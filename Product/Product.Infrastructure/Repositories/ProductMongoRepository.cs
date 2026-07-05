using Microservice.Core.Interfaces;
using MongoDB.Driver;
using Product.Domian.Documents;
using Product.Infrastructure.Configurations;

namespace Product.Infrastructure.Repositories;

public sealed class ProductMongoRepository(IMongoDbContext context) : IScopedDependency, IProductMongoRepository
{
    public async Task UpsertAsync(ProductDocument product, CancellationToken cancellationToken)
    {
        await context.Products.ReplaceOneAsync(x => x.Id == product.Id, product, new ReplaceOptions { IsUpsert = true }, cancellationToken);
    }
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await context.Products.DeleteOneAsync(x => x.Id == id, cancellationToken);
    }
}