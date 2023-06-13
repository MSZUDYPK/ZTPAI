using CultureSpot.Core.Events.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CultureSpot.Core.Users.ValueObjects;
using CultureSpot.Core.Events.ValueObjects;
using CultureSpot.Core.Users.Entities;

namespace CultureSpot.Infrastructure.DAL.Configurations;


internal sealed class AttendeeConfiguration : IEntityTypeConfiguration<Attendee>
{
    public void Configure(EntityTypeBuilder<Attendee> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new AttendeeId(x));

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(a => a.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Event>()
            .WithMany()
            .HasForeignKey(a => a.EventId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}