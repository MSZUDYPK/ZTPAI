using CultureSpot.Core.Events.Entities;
using CultureSpot.Core.Events.Repositories;
using CultureSpot.Core.Shared.ValueObjects;
using CultureSpot.Infrastructure.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CultureSpot.Infrastructure.DAL.Repositories;

internal class PostgresOrganizerRepository : IOrganizerRepository
{
    private readonly DbSet<Organizer> _organizers;

    public PostgresOrganizerRepository(CultureSpotDbContext dbContext)
    {
        _organizers = dbContext.Organizers;
    }

    public async Task<Organizer> GetByName(Name name)
    => await _organizers
                .Where(x => x.Name == name)
                .SingleOrDefaultAsync();
}
