using Microservice.Core.Exceptions;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Product.Domain.ValueObjects;

public sealed record Money
{
    public long Amount { get; }
    public Currency Currency { get; }

    public static Money Zero => new(0, Currency.IRR);

    public Money(long amount, Currency currency)
    {
        if (amount < 0)
            throw new DomainException("Amount cannot be negative.");

        Amount = amount;
        Currency = currency;
    }

    public Money Add(Money other)
    {
        EnsureSameCurrency(other);
        return new Money(Amount + other.Amount, Currency);
    }

    public Money Subtract(Money other)
    {
        EnsureSameCurrency(other);

        if (Amount < other.Amount)
            throw new DomainException("Amount cannot be negative.");

        return new Money(Amount - other.Amount, Currency);
    }

    private void EnsureSameCurrency(Money other)
    {
        if (Currency != other.Currency)
            throw new DomainException("Currencies must be the same.");
    }

    public override string ToString() => $"{Amount:N0} {Currency}";
    public long GetValue() => Amount;
}
public sealed record Quantity
{
    public int Value { get; }

    public static Quantity Zero => new(0);

    public Quantity(int value)
    {
        if (value < 0)
            throw new DomainException("Quantity cannot be negative.");

        Value = value;
    }

    public Quantity Increase(int amount)
    {
        if (amount <= 0)
            throw new DomainException("Increase amount must be greater than zero.");

        return new Quantity(Value + amount);
    }

    public Quantity Decrease(int amount)
    {
        if (amount <= 0)
            throw new DomainException("Decrease amount must be greater than zero.");

        if (Value < amount)
            throw new DomainException("Insufficient quantity.");

        return new Quantity(Value - amount);
    }

    public override string ToString() => Value.ToString();

    public static implicit operator int(Quantity quantity) => quantity.Value;

    public static explicit operator Quantity(int value) => new(value);
}