using Order.Domain.Enums;

namespace Order.Application.Orders.DTOs;

public sealed record ChangeOrderStatusDto(long OrderId, OrderStatus Status);
