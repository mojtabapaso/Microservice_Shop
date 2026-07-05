namespace Order.Application.Basket.DTOs;

public class BasketItemDTO
{
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
