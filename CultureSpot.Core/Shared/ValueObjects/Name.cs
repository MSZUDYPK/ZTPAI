using CultureSpot.Core.Shared.Exceptions;

namespace CultureSpot.Core.Shared.ValueObjects;

public sealed record Name
{
    public string Value { get; }

    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidNameException(value);
        }

        if (value.Length is > 45 or < 3)
        {
            throw new InvalidNameException(value);
        }

        Value = value;
    }

    public static implicit operator Name(string value) => new(value);

    public static implicit operator string(Name value) => value?.Value;

    public override string ToString() => Value;
}
