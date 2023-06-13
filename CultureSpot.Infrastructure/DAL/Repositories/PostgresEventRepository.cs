using CultureSpot.Core.Events.Entities;
using CultureSpot.Core.Events.Repositories;
using CultureSpot.Core.Events.ValueObjects;
using CultureSpot.Core.Shared.ValueObjects;
using CultureSpot.Infrastructure.DAL.Context;
using Microsoft.EntityFrameworkCore;


namespace CultureSpot.Infrastructure.DAL.Repositories;

internal class PostgresEventRepository : IEventRepository
{
    private readonly DbSet<Event> _events;

    public PostgresEventRepository(CultureSpotDbContext dbContext)
    {
        _events = dbContext.Events;
    }

    public async Task AddAsync(Event eventObj)
        => await _events.AddAsync(eventObj);

    public async Task AddImageAsync(EventId id, ImageUrl imageUrl)
    {    
        var eventEntity = await _events.FindAsync(id);

        if (eventEntity is null) {
            return;
        }
        
        eventEntity.ImageUrl = imageUrl;
    }

    public async Task<IEnumerable<Event>> GetAllAsync()
        => await _events.ToListAsync();

    public async Task<Event> GetByIdAsync(EventId id)
        => await _events.SingleOrDefaultAsync(x => x.Id == id);
}
