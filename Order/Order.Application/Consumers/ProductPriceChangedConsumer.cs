using MassTransit;
using Microservice.Contracts.IntegrationEvent;
using Microservice.Core.Interfaces;
using Order.Infrastructure.Repositories;

namespace Order.Application.Consumers;

public class ProductPriceChangedConsumer(IBasketRepository basketRepository, IUnitOfWork unitOfWork) : IConsumer<ProductPriceChangedEvent>
{
    public async Task Consume(ConsumeContext<ProductPriceChangedEvent> context)
    {
        var baskets = await basketRepository.GetBasketsByProductIdAsync(context.Message.ProductId, CancellationToken.None);
        foreach (var basket in baskets)
        {
            basket.ChangeProductPrice(context.Message.ProductId, context.Message.NewPrice);
        }
        await unitOfWork.SaveChangesAsync(CancellationToken.None);
    }
}