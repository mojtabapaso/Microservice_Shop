using Microservice.Core.EventPublisher;

namespace Product.Application.Product.Events;

public sealed record ProductDeletedEvent(Guid ProductId) : IEvent;
