namespace CultureSpot.Core.Events.ValueObjects;

public sealed record Location
{
    public string Value { get; }

    public Location(string value)
    {
        Value = value;
    }

    public static implicit operator Location(string value) => new(value);

    public static implicit operator string(Location value) => value?.Value;

    public override string ToString() => Value;
}
