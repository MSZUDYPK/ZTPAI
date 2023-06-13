using CultureSpot.Core.Events.Entities;
using CultureSpot.Core.Events.ValueObjects;
using CultureSpot.Core.Shared.ValueObjects;

namespace CultureSpot.Core.Events.Repositories;

public interface IEventRepository
{
    Task<Event> GetByIdAsync(EventId id);
    Task<IEnumerable<Event>> GetAllAsync();
    Task AddAsync(Event eventObj);
    Task AddImageAsync(EventId id, ImageUrl imageUrl);
}