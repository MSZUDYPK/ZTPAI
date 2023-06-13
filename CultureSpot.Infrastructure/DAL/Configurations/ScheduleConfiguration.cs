using CultureSpot.Core.Events.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CultureSpot.Core.Events.ValueObjects;

namespace CultureSpot.Infrastructure.DAL.Configurations;

internal sealed class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.HasKey(x => x.ScheduleId);
        builder.Property(x => x.ScheduleId)
            .HasConversion(x => x.Value, x => new ScheduleId(x));
        builder.HasMany(x => x.ScheduleItems)
            .WithOne()
            .HasForeignKey("ScheduleId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}