namespace CultureSpot.Application.Exceptions;

internal class EventNotFoundException : Exception
{
    public Guid EventId { get; }

    public EventNotFoundException(Guid eventId) : base($"Event with ID: '{eventId}' was not found.")
    {
        EventId = eventId;
    }
}