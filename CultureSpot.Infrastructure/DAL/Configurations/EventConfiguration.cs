using CultureSpot.Core.Events.Entities;
using CultureSpot.Core.Events.Enums;
using CultureSpot.Core.Events.ValueObjects;
using CultureSpot.Core.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CultureSpot.Infrastructure.DAL.Configurations;

internal sealed class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new EventId(x));

        builder.HasOne(x => x.Organizer);

        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => new Name(x))
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasConversion(x => x.Value, x => new Description(x))
            .IsRequired()
            .HasMaxLength(1000);

        builder.HasOne(x => x.Schedule);

        builder.Property(x => x.Date)
            .IsRequired();

        builder.Property(x => x.Type)
            .HasConversion(x => x.ToString(), x => (EventType)Enum.Parse(typeof(EventType), x))
            .IsRequired();

        builder.Property(x => x.Price)
            .HasConversion(x => x.Value, x => new Price(x))
            .IsRequired();

        builder.Property(x => x.Location)
            .HasConversion(x => x.Value, x => new Location(x))
            .IsRequired();

        builder.Property(x => x.Capacity)
            .HasConversion(x => x.Value, x => new Capacity(x))
            .IsRequired();

        builder.Property(x => x.ImageUrl)
        .HasConversion(x => x.Value, x => new ImageUrl(x))
        .IsRequired();
    }
}
