using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Product.Domain.Documents;

public class ProductDocument
{
    [BsonId]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public long Price { get; set; }

    public int Stock { get; set; }

    public string SKU { get; set; } = null!;
}
