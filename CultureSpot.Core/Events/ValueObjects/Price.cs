namespace CultureSpot.Core.Events.ValueObjects;

public sealed record Price
{
    public decimal Value { get; }

    public Price(decimal value)
    {
        if (value < 0)
        {
            // TODO: ZAMIENIĆ EXCEPTION NA DOMENOWY
            throw new ArgumentOutOfRangeException(nameof(value), "Price cannot be negative.");
        }

        Value = value;
    }

    public static implicit operator Price(decimal value) => new(value);

    public static implicit operator decimal(Price value) => value?.Value ?? 0;

    public override string ToString() => $"{Value:C}";
}
