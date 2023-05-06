using CultureSpot.Core.Users.Exceptions;

namespace CultureSpot.Core.Users.ValueObjects;

public sealed record Password
{
    public string Value { get; }

    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidPasswordException();
        }

        if (value.Length is > 200 or < 6)
        {
            throw new InvalidPasswordException();
        }

        Value = value;
    }

    public static implicit operator Password(string value) => new(value);

    public static implicit operator string(Password value) => value?.Value;

    public override string ToString() => Value;
}