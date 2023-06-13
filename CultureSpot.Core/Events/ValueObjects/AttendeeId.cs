using CultureSpot.Core.Shared.Exceptions;

namespace CultureSpot.Core.Events.ValueObjects;

public sealed record AttendeeId
{
    public Guid Value { get; }

    public AttendeeId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static implicit operator Guid(AttendeeId date) => date.Value;

    public static implicit operator AttendeeId(Guid value) => new(value);
}

