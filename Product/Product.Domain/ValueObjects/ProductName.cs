using Microservice.Core.Exceptions;

namespace Product.Domain.ValueObjects;

public sealed record ProductName
{
    public string Value { get; }

    public ProductName(string value)
    {
        value = value.Trim();

        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Product name is required.");

        if (value.Length > 150)
            throw new DomainException("Product name is too long.");

        Value = value;
    }
    public string GetValue() => Value;

    public static implicit operator string(ProductName value)   => value.Value;


}
