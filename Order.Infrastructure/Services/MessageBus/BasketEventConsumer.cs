using MassTransit;
using Order.Infrastructure.Persistence.Repositories;
using Sheard.Interfaces;
//using Order.Application.Basket.Events;

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