using Microservice.Core.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Product.Domian.Documents;

namespace Product.Infrastructure.Configurations;

public sealed class MongoDbContext : ISingletonDependency, IMongoDbContext
{
    public IMongoCollection<ProductDocument> Products { get; }

    public MongoDbContext(IOptions<MongoOptions> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);

        var database = client.GetDatabase(options.Value.DatabaseName);

        Products = database.GetCollection<ProductDocument>("Products");
    }
}
