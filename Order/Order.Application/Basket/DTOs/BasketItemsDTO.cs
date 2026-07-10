namespace Order.Application.Basket.DTOs;

public sealed record GetBasketDTO(long UserId);
public sealed record UpdateBasketItemQuantityDTO(long UserId, Guid ProductId, int NewQuantity);
public sealed record BasketItemsDTO(Guid ProductId, int Quantity, decimal UnitPrice);
public sealed record RemoveBasketItemDTO(long UserId, Guid ProductId);
public sealed record ClearBasketDTO(long UserId);

