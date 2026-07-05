using MassTransit;

namespace Product.Application.Product.Events;

public class ProductPriceChangedConsumer : IConsumer<ProductPriceChangedEvent>
{
    public Task Consume(ConsumeContext<ProductPriceChangedEvent> context)
    {
        throw new NotImplementedException();
    }
}