using MassTransit;
using Product.Domain.Documents;
using Product.Infrastructure.Repositories;

namespace Product.Application.Product.Events;

public class ProductUpdatedConsumer(IProductMongoRepository productMongoRepository, IProductRepository productRepository) : IConsumer<ProductUpdatedEvent>
{
    public async Task Consume(ConsumeContext<ProductUpdatedEvent> context)
    {
        var product = await productRepository.FindByRowIdAsync(context.Message.ProductId);
        if (product is null) return;
        await productMongoRepository.UpsertAsync(new ProductDocument
        {
            Id = product.RowId,
            Description = product.Description,
            Name = product.Name,
            Price = product.Price,
            SKU = product.SKU,
            Stock = product.Stock
        }, CancellationToken.None); // TODO CancellationToken.None get from above later
    }
}
