using CultureSpot.Core.Events.Entities;
using CultureSpot.Core.Shared.ValueObjects;

namespace CultureSpot.Core.Events.Repositories;

public interface IOrganizerRepository
{
    Task<Organizer> GetByName(Name name);
}