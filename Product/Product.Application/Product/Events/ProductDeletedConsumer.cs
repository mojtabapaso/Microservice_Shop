using MassTransit;
using Product.Infrastructure.Repositories;

namespace Product.Application.Product.Events;

public class ProductDeletedConsumer(IProductMongoRepository productMongoRepository) : IConsumer<ProductDeletedEvent>
{
    public async Task Consume(ConsumeContext<ProductDeletedEvent> context)
    {
        await productMongoRepository.DeleteAsync(context.Message.ProductId
        , CancellationToken.None); // TODO CancellationToken.None get from above later    }
    }
}
