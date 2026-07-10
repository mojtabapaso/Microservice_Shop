namespace Order.Application.Orders.DTOs;

public sealed record CancelOrderDto(long OrderId, Guid UserId, string? Reason);
