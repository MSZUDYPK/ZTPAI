using CultureSpot.Core.Events.Entities;
using CultureSpot.Core.Events.Enums;
using CultureSpot.Core.Events.Repositories;
using CultureSpot.Core.Events.ValueObjects;

namespace CultureSpot.Infrastructure.DAL.Repositories;

internal sealed class InMemoryEventRepository : IEventRepository
{

    private readonly List<Event> _events;

    public InMemoryEventRepository()
    {
        _events = new List<Event>
        {
            new Event(Guid.Parse("00000000-0000-0000-0000-000000000001"), 
            new OrganizerId(Guid.Parse("00000000-0000-0000-0000-000000000001")),
            "name",
            "desc",
            new ScheduleId(Guid.Parse("00000000-0000-0000-0000-000000000001")),
            EventType.Exhibition,
            20,
            new LocationId(Guid.Parse("00000000-0000-0000-0000-000000000001")),
            50
            ),
            new Event(Guid.Parse("00000000-0000-0000-0000-000000000002"),
            new OrganizerId(Guid.Parse("00000000-0000-0000-0000-000000000002")),
            "name2",
            "desc2",
            new ScheduleId(Guid.Parse("00000000-0000-0000-0000-000000000002")),
            EventType.Exhibition,
            25,
            new LocationId(Guid.Parse("00000000-0000-0000-0000-000000000002")),
            55
            )
        };
    }

    public Task AddAsync(Event eventObj)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Event>> GetAllAsync() => Task.FromResult(
        _events
        .AsEnumerable());

    public Task<Event> GetByIdAsync(EventId id) => Task.FromResult(
        _events
        .AsEnumerable()
        .SingleOrDefault(x => x.Id == id));

}