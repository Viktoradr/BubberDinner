using BuberDinner.Domain.HostAggregate;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.EFCore.Configurations;

public class HostConfigurations : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        ConfigureHostsTable(builder);
        ConfigureHostMenuIdsTable(builder);
        ConfigureHostDinnerIdsTable(builder);
    }

    private void ConfigureHostsTable(EntityTypeBuilder<Host> builder)
    {
        builder.ToTable("Hosts");

        builder.HasKey(nameof(Host.Id));

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.Property(x => x.FirstName).HasMaxLength(100);
        builder.Property(x => x.LastName).HasMaxLength(100);
        builder.Property(x => x.ProfileImage);

        builder.OwnsOne(x => x.AverageRating);

        builder.Property(x => x.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
    }

    private void ConfigureHostMenuIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(x => x.MenuIds, mib =>
        {
            mib.WithOwner().HasForeignKey("HostId");

            mib.ToTable("HostMenuIds");

            mib.HasKey("Id");

            mib.Property(mi => mi.Value)
                .ValueGeneratedNever()
                .HasColumnName("HostMenuId");
        });

        builder.Metadata.FindNavigation(nameof(Host.MenuIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureHostDinnerIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(x => x.DinnerIds, mib =>
        {
            mib.WithOwner().HasForeignKey("HostId");

            mib.ToTable("HostDinnerIds");

            mib.HasKey("Id");

            mib.Property(mi => mi.Value)
                .ValueGeneratedNever()
                .HasColumnName("HostDinnerId");
        });

        builder.Metadata.FindNavigation(nameof(Host.DinnerIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
