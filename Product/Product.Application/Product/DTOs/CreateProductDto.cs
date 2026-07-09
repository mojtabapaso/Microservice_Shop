using Product.Domain.ValueObjects;

namespace Product.Application.Product.DTOs;
//Admin Role
public sealed record CreateProductDto(string Name, string Description, long Price, int Stock, string SKU);
public sealed record UpdateProductDto(long ProductId, string Name, string Description, long Price, string SKU);
public sealed record ChangeProductPriceDto(long ProductId, long NewPrice);
public sealed record DeleteProductDto(long ProductId);
//Query
public sealed record GetProductDto(long ProductId);

// client role
public sealed record GetProductByPublicIdDto(Guid ProductId);

