using MongoDB.Driver;
using Product.Domian.Documents;

namespace Product.Infrastructure.Configurations;

public interface IMongoDbContext
{
    IMongoCollection<ProductDocument> Products { get; }
}