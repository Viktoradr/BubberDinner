using BuberDinner.Domain.DinnerAggregate;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.Entities;

namespace BuberDinner.Infrastructure.Persistence.EFCore.Configurations;

public class DinnerConfigurations : IEntityTypeConfiguration<Dinner>
{
    public void Configure(EntityTypeBuilder<Dinner> builder)
    {
        ConfigureDinnersTable(builder);
        ConfigureDinnerReservationsTable(builder);
    }

    private void ConfigureDinnersTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.ToTable("Dinners");

        builder.HasKey(nameof(Dinner.Id));

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));

        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(100);
        builder.Property(x => x.StartDateTime);
        builder.Property(x => x.StartedDateTime);
        builder.Property(x => x.EndendDateTime);
        builder.Property(x => x.IsPublic);
        builder.Property(x => x.MaxGuests);
        builder.Property(x => x.ImageUrl);

        builder.Property(x => x.Price);
        builder.Property(x => x.Location);

        //builder.Property(x => x.Status)
        //        .HasConversion(
        //            status => status.Value,
        //            value => DinnerStatus.FromValue(value));

        builder.Property(x => x.MenuId)
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

        builder.Property(x => x.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));
    }

    private void ConfigureDinnerReservationsTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.OwnsMany(x => x.Reservations, rb =>
        {
            rb.ToTable("DinnerReservations");

            rb.HasKey("Id");

            rb.Property(x => x.Id)
                .HasColumnName("ReservationId")
                .ValueGeneratedNever();

            rb.Property(x => x.GuestCount);
            rb.Property(x => x.ArrivalDateTime);

            rb.Property(x => x.BillId)
                .HasConversion(
                    id => id!.Value,
                    value => BillId.Create(value));

            rb.Property(x => x.GuestId)
                .HasConversion(
                    id => id!.Value,
                    value => GuestId.Create(value));

            //rb.Property(x => x.Status)
            //        .HasConversion(
            //            status => status.Value,
            //            value => ReservationStatus.FromValue(value));
        });

        builder.Metadata.FindNavigation(nameof(Dinner.Reservations))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
