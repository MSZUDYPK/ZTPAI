using Microsoft.EntityFrameworkCore;
using CultureSpot.Core.Events.Entities;
using CultureSpot.Core.Users.Entities;

namespace CultureSpot.Infrastructure.DAL.Context;

public class CultureSpotDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<User> Users { get; set; }

    public CultureSpotDbContext(DbContextOptions<CultureSpotDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}