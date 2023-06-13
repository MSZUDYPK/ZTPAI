namespace CultureSpot.Core.Events.ValueObjects;

public sealed record Capacity
{
    public int Value { get; }

    public Capacity(int value)
    {
        if (value < 0)
        {
            // TODO: ZAMIENIĆ EXCEPTION NA DOMENOWY
            throw new ArgumentOutOfRangeException(nameof(value), "Capacity cannot be negative.");
        }

        Value = value;
    }

    public static implicit operator Capacity(int value) => new(value);

    public static implicit operator int(Capacity value) => value?.Value ?? 0;

    public override string ToString() => $"{Value:N} units";
}