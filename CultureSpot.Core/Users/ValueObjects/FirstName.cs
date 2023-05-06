using CultureSpot.Core.Users.Exceptions;

namespace CultureSpot.Core.Users.ValueObjects;

public sealed record FirstName
{
    public string Value { get; }

    public FirstName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidFirstNameException(value);
        }

        if (value.Length is > 100 or < 3)
        {
            throw new InvalidFirstNameException(value);
        }

        Value = value;
    }

    public static implicit operator FirstName(string value) => value is null ? null : new FirstName(value);

    public static implicit operator string(FirstName value) => value?.Value;

    public override string ToString() => Value;
}