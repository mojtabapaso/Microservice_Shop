namespace Order.Application.Orders.DTOs;

public sealed record CreateOrderDto(Guid BasketId, Guid UserId, string? Description);
