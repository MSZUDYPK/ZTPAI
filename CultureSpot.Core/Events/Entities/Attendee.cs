using CultureSpot.Core.Events.ValueObjects;
using CultureSpot.Core.Users.ValueObjects;

namespace CultureSpot.Core.Events.Entities;

public class Attendee
{
    public AttendeeId Id { get; private set; }
    public UserId UserId { get; private set; }
    public EventId EventId { get; private set; }

    private Attendee()
    {
    }

    public Attendee(AttendeeId id, UserId userId, EventId eventId)
    {
        Id = id;
        UserId = userId;
        EventId = eventId;
    }
}
