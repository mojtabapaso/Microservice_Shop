namespace Order.Application.Orders.DTOs;

public sealed record GetMyOrdersDto(Guid UserId, int Page = 1, int PageSize = 20);
