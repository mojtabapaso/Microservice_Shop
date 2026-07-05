using MassTransit;

//namespace Order.Infrastructure.Services.MessageBus;

//public class BasketEventConsumer(IBasketRepository basketRepository, IUnitOfWork unitOfWork) : IConsumer //<BasketItemAddedEvent>
//{
//    public async Task Consume(ConsumeContext context)//<BasketItemAddedEvent> context)
//    {
//        //var basket = await basketRepository.FindByIdAsync(context.Message.BasketId);
//        //basket.MarkAsUpdated();
//        //basketRepository.Update(basket);
//        //await unitOfWork.SaveChangesAsync();
//    }
//}