namespace CultureSpot.Core.Events.ValueObjects;

public sealed record Capacity
{
    public decimal Value { get; }

    public Capacity(decimal value)
    {
        if (value < 0)
        {
            // TODO: ZAMIENIĆ EXCEPTION NA DOMENOWY
            throw new ArgumentOutOfRangeException(nameof(value), "Capacity cannot be negative.");
        }

        Value = value;
    }

    public static implicit operator Capacity(decimal value) => new(value);

    public static implicit operator decimal(Capacity value) => value?.Value ?? 0;

    public override string ToString() => $"{Value:N} units";
}