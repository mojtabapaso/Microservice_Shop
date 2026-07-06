using Microservice.Core.EventPublisher;

namespace Microservice.Contracts.IntegrationEvent;

public sealed record ProductPriceChangedEvent(Guid ProductId,long NewPrice) : IIntegrationEvent;

//TODO cahgen to public product Id guid

