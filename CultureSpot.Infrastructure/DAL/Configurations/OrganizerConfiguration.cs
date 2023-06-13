using CultureSpot.Core.Events.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CultureSpot.Core.Events.ValueObjects;
using CultureSpot.Core.Shared.ValueObjects;
using CultureSpot.Core.Users.ValueObjects;
using CultureSpot.Core.Users.Entities;

namespace CultureSpot.Infrastructure.DAL.Configurations;

internal sealed class OrganizerConfiguration : IEntityTypeConfiguration<Organizer>
{
    public void Configure(EntityTypeBuilder<Organizer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new OrganizerId(x));

        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => new Name(x));

        builder.Property(x => x.UserId)
        .HasConversion(x => x.Value, x => new UserId(x));

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}