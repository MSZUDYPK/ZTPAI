using CultureSpot.Core.Events.Enums;
using CultureSpot.Core.Events.ValueObjects;
using CultureSpot.Core.Shared.ValueObjects;

namespace CultureSpot.Core.Events.Entities;

public class Event
{
    public EventId Id { get; private set; }
    public OrganizerId OrganizerId { get; private set; }
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public ScheduleId ScheduleId { get; private set; }

    public EventType Type { get; private set; }
    public Price Price { get; private set; }
    public LocationId LocationId { get; private set; }
    public Capacity Capacity { get; private set; }

    public Event(
        EventId id, 
        OrganizerId organizerId, 
        Name name, 
        Description description, 
        ScheduleId scheduleId, 
        EventType type, 
        Price price, 
        LocationId locationId, 
        Capacity capacity)
    {
        Id = id;
        OrganizerId = organizerId;
        Name = name;
        Description = description;
        ScheduleId = scheduleId;
        Type = type;
        Price = price;
        LocationId = locationId;
        Capacity = capacity;
    }
}
