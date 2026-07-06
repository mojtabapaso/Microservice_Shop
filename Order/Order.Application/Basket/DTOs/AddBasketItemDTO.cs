namespace Order.Application.Basket.DTOs;

public class AddBasketItemDTO
{
    public long UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
