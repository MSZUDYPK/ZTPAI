using CultureSpot.Core.Shared.Exceptions;

namespace CultureSpot.Application.Exceptions;

internal class EventNotFoundException : CustomException
{
    public Guid EventId { get; }

    public EventNotFoundException(Guid eventId) : base($"Event with ID: '{eventId}' was not found.")
        => EventId = eventId;
}