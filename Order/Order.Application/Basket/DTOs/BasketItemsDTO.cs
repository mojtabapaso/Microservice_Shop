namespace Order.Application.Basket.DTOs;

public class BasketItemsDTO
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}