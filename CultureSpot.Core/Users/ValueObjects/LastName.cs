using CultureSpot.Core.Users.Exceptions;

namespace CultureSpot.Core.Users.ValueObjects;

public sealed record LastName
{
    public string Value { get; }

    public LastName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidLastNameException(value);
        }

        if (value.Length is > 100 or < 3)
        {
            throw new InvalidLastNameException(value);
        }

        Value = value;
    }

    public static implicit operator LastName(string value) => value is null ? null : new LastName(value);

    public static implicit operator string(LastName value) => value?.Value;

    public override string ToString() => Value;
}