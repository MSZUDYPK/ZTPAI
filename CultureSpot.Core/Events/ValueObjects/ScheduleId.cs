using CultureSpot.Core.Shared.Exceptions;

namespace CultureSpot.Core.Events.ValueObjects;

public sealed record ScheduleId
{
    public Guid Value { get; }

    public ScheduleId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }

    public static implicit operator Guid(ScheduleId date) => date.Value;

    public static implicit operator ScheduleId(Guid value) => new(value);
}