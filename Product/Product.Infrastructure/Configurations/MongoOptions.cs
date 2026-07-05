namespace Product.Infrastructure.Configurations;

public sealed class MongoOptions
{
    public const string SectionName = "Mongo";

    public string ConnectionString { get; init; } = null!;

    public string DatabaseName { get; init; } = null!;
}
