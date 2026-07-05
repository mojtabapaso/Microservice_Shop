//using MassTransit;
//using Order.Infrastructure.MarkerInterfaces;
//using Sheard.Abstraction.Interfaces;
//namespace Order.Infrastructure.Services.MessageBus;


//public class BasketEventPublisher : IScopedDependency, IBasketEventPublisher
//{
//    private readonly IPublishEndpoint publishEndpoint;

//    public BasketEventPublisher(IPublishEndpoint publishEndpoint)
//    {
//        this.publishEndpoint = publishEndpoint;
//    }
//    public async Task PublicAsync<TEvent>(TEvent @event) where TEvent : IEventDomain
//    {
//        await publishEndpoint.Publish(@event);

//    }
//}
