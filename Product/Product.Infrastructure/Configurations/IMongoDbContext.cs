using MongoDB.Driver;
using Product.Domain.Documents;

namespace Product.Infrastructure.Configurations;

public interface IMongoDbContext
{
    IMongoCollection<ProductDocument> Products { get; }
}