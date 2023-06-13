using CultureSpot.Core.Events.Enums;
using CultureSpot.Core.Events.ValueObjects;
using CultureSpot.Core.Shared.ValueObjects;

namespace CultureSpot.Core.Events.Entities;

public class Event
{
    public EventId Id { get; private set; }
    public Organizer Organizer { get; private set; }
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Schedule Schedule { get; private set; }
    public DateOnly Date { get; private set; }

    public EventType Type { get; private set; }
    public Price Price { get; private set; }
    public Location Location { get; private set; }
    public Capacity Capacity { get; private set; }

    public ImageUrl ImageUrl { get; set; }

    private Event()
    {
    }

    public Event(
        EventId id,
        Organizer organizer,
        Name name,
        Description description,
        Schedule schedule,
        DateOnly date,
        EventType type,
        Price price,
        Location location,
        Capacity capacity,
        ImageUrl imageUrl)
    {
        Id = id;
        Organizer = organizer;
        Name = name;
        Description = description;
        Schedule = schedule;
        Date = date;
        Type = type;
        Price = price;
        Location = location;
        Capacity = capacity;
        ImageUrl = imageUrl;
    }


}
