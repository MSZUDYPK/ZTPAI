using CultureSpot.Core.Events.Entities;
using CultureSpot.Core.Events.ValueObjects;

namespace CultureSpot.Core.Events.Repositories;

public interface IEventRepository
{
    Task<Event> GetByIdAsync(EventId id);
    Task<IEnumerable<Event>> GetAllAsync();
    Task AddAsync(Event eventObj);
}