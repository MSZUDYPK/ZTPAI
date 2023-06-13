using CultureSpot.Core.Events.ValueObjects;
using CultureSpot.Core.Shared.ValueObjects;
using CultureSpot.Core.Users.ValueObjects;

namespace CultureSpot.Core.Events.Entities;

public class Organizer
{
    public OrganizerId Id { get; private set; }
    public Name Name { get; private set; }
    public UserId UserId { get; private set; }

    private Organizer()
    {
    }

    public Organizer(OrganizerId id, Name name, UserId userId)
    {
        Id = id;
        Name = name;
        UserId = userId;
    }
}