using Order.Domain.Enums;

namespace Order.Domain.Entities;

public sealed class Order
{
    public Order()
    {
    }

    public Order(Guid basketId, Guid userId, string? description)
    {
        BasketId = basketId;
        UserId = userId;
        Description = description;

        Status = OrderStatus.Pending;

        CreatedAt = DateTime.UtcNow;
    }

    public long Id { get; private set; }

    public Guid BasketId { get; private set; }

    public Guid UserId { get; private set; }

    public string? Description { get; private set; }

    public OrderStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? ConfirmedAt { get; private set; }

    public DateTime? CancelledAt { get; private set; }

    public DateTime? DeliveredAt { get; private set; }

    public string? CancelReason { get; private set; }

    #region Methods

    public void Confirm()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Only pending orders can be confirmed.");

        Status = OrderStatus.Confirmed;
        ConfirmedAt = DateTime.UtcNow;
    }

    public void StartProcessing()
    {
        if (Status != OrderStatus.Confirmed)
            throw new InvalidOperationException("Order must be confirmed.");

        Status = OrderStatus.Processing;
    }

    public void Ship()
    {
        if (Status != OrderStatus.Processing)
            throw new InvalidOperationException("Order must be processing.");

        Status = OrderStatus.Shipped;
    }

    public void Deliver()
    {
        if (Status != OrderStatus.Shipped)
            throw new InvalidOperationException("Order must be shipped.");

        Status = OrderStatus.Delivered;
        DeliveredAt = DateTime.UtcNow;
    }

    public void Cancel(string? reason)
    {
        if (Status == OrderStatus.Delivered)
            throw new InvalidOperationException("Delivered orders cannot be cancelled.");

        if (Status == OrderStatus.Cancelled)
            throw new InvalidOperationException("Order is already cancelled.");

        Status = OrderStatus.Cancelled;
        CancelReason = reason;
        CancelledAt = DateTime.UtcNow;
    }

    public void ChangeDescription(string? description)
    {
        Description = description;
    }

    #endregion
}