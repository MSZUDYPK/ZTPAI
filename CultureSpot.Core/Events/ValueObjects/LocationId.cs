using CultureSpot.Core.Shared.Exceptions;

namespace CultureSpot.Core.Events.ValueObjects;

public sealed record LocationId
{
    public Guid Value { get; }

    public LocationId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static implicit operator Guid(LocationId date) => date.Value;

    public static implicit operator LocationId(Guid value) => new(value);
}
