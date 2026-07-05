using Microservice.Core.EventPublisher;

namespace Product.Application.Product.Events;

// for publish in message brocker for other service
public sealed record ProductPriceChangedEvent(long ProductId) : IEvent;
