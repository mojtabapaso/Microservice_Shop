using MediatR;

namespace Order.Application.Basket.Events;

public record BasketItemAddedEvent(long basketId) : IRequest;
