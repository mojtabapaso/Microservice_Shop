using Microservice.Core.EventPublisher;

namespace Product.Application.Product.Events;

public sealed record ProductUpdatedEvent(Guid ProductId) : IEvent;
