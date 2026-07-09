using Microservice.Core;
using Product.Domain.ValueObjects;

namespace Product.Domain.Entities;

public class Product : BaseEntity
{
    public long Id { get; private set; }
    public Guid RowId { get; private set; }
    public ProductName Name { get; private set; } = null!;

    public string? Description { get; private set; }

    public Money Price { get; private set; }

    public int Stock { get; private set; }

    public string SKU { get; private set; } = null!;

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public Product()
    {
        // For EF Core
    }

    public Product(ProductName name, string? description, Money price, int stock, string sku)
    {
        Name =  name;
        Description = description;
        Price = price;
        Stock = stock;
        SKU = sku;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        RowId = Guid.NewGuid();
    }

    public void UpdateInformation(ProductName name,string? description, Money price, string sku)
    {
        Name = name;
        Description = description;
        Price = price;
        SKU = sku;

        UpdatedAt = DateTime.UtcNow;
    }

    public void IncreaseStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        Stock += quantity;
        UpdatedAt = DateTime.UtcNow;
    }

    public void DecreaseStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        if (Stock < quantity)
            throw new InvalidOperationException("Insufficient stock.");

        Stock -= quantity;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        IsActive = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangePrice(Money price)
    {
        Price = price;
        UpdatedAt = DateTime.UtcNow;
    }
}