using MassTransit;
using Product.Domian.Documents;
using Product.Infrastructure.Repositories;

namespace Product.Application.Product.Events;

public class ProductUpdatedConsumer(IProductMongoRepository productMongoRepository, IProductRepository productRepository) : IConsumer<ProductUpdatedEvent>
{
    public async Task Consume(ConsumeContext<ProductUpdatedEvent> context)
    {
        var product = await productRepository.FindByRowIdAsync(context.Message.ProductId);
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
