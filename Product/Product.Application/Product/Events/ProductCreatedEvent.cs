using Microservice.Core.EventPublisher;

namespace Product.Application.Product.Events;

public sealed record ProductCreatedEvent(Guid ProductId) : IEvent;
