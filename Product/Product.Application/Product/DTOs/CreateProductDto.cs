namespace Product.Application.Product.DTOs;

public sealed record CreateProductDto(string Name, string Description, long Price, int Stock, string SKU);
public sealed record UpdateProductDto(long ProductId,string Name, string Description, long Price, string SKU);
public sealed record ChangeProductPriceDto(long ProductId, long NewPrice);
