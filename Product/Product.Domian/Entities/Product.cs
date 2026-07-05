namespace Product.Domian.Entities;

public class Product
{
    public long Id { get; private set; }

    public string Name { get; private set; } = null!;

    public string? Description { get; private set; }

    public long Price { get; private set; }

    public int Stock { get; private set; }

    public string SKU { get; private set; } = null!;

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public Product()
    {
        // For EF Core
    }

    public Product(string name, string? description, long price, int stock, string sku)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        SKU = sku;

        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateInformation(string name,string? description, long price, string sku)
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

    public void ChangePrice(long price)
    {
        if (price < 0)
            throw new ArgumentException("Price cannot be negative.");

        Price = price;
        UpdatedAt = DateTime.UtcNow;
    }
}