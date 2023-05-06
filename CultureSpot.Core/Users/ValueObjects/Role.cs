using CultureSpot.Core.Users.Exceptions;

namespace CultureSpot.Core.Users.ValueObjects;

public sealed record Role
{
    public string Value { get; }

    public Role(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidRoleException(value);
        }

        Value = value;
    }

    public static implicit operator Role(string value) => new Role(value);

    public static implicit operator string(Role value) => value?.Value;

    public override string ToString() => Value;
}