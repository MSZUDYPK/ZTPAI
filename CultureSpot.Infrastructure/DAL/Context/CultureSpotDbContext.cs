using Microsoft.EntityFrameworkCore;
using CultureSpot.Core.Events.Entities;
using CultureSpot.Core.Users.Entities;
using CultureSpot.Infrastructure.DAL.Configurations;

namespace CultureSpot.Infrastructure.DAL.Context;

public class CultureSpotDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<ScheduleItem> ScheduleItems { get; set; }

    public CultureSpotDbContext(DbContextOptions<CultureSpotDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}