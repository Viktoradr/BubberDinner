using BuberDinner.Domain.GuestAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.EFCore.Configurations;

public class GuestConfigurations : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        throw new NotImplementedException();

        //GuestBillIds
        //GuestMenuReviewIds
        //GuestPastDinnerIds
        //GuestPendingDinnerIds
        //GuestRatings
        //Guests
        //GuestUpcomingDinnerIds
    }
}
