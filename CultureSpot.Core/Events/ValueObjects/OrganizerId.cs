using CultureSpot.Core.Shared.Exceptions;

namespace CultureSpot.Core.Events.ValueObjects;

public sealed record OrganizerId
{
    public Guid Value { get; }

    public OrganizerId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static implicit operator Guid(OrganizerId date) => date.Value;

    public static implicit operator OrganizerId(Guid value) => new(value);
}
