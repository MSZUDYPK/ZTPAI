using CultureSpot.Core.Events.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CultureSpot.Core.Events.ValueObjects;
using CultureSpot.Core.Shared.ValueObjects;

namespace CultureSpot.Infrastructure.DAL.Configurations;

internal sealed class ScheduleItemConfiguration : IEntityTypeConfiguration<ScheduleItem>
{
    public void Configure(EntityTypeBuilder<ScheduleItem> builder)
    {
        builder.HasKey(x => x.ScheduleItemId);
        builder.Property(x => x.ScheduleItemId);
        builder.Property(x => x.ScheduleId)
            .HasConversion(x => x.Value, x => new ScheduleId(x));
        builder.Property(x => x.StartTime);
        builder.Property(x => x.EndTime);
        builder.Property(x => x.Date);
        builder.Property(x => x.Description)
            .HasConversion(x => x.Value, x => new Description(x));
        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => new Name(x));
    }
}
