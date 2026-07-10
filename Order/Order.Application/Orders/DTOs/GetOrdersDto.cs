namespace Order.Application.Orders.DTOs;

public sealed record GetOrdersDto(int Page = 1, int PageSize = 20);
