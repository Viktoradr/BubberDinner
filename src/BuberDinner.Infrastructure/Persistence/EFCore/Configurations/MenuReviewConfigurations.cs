using BuberDinner.Domain.MenuReviewAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.EFCore.Configurations;

public class MenuReviewConfigurations : IEntityTypeConfiguration<MenuReview>
{
    public void Configure(EntityTypeBuilder<MenuReview> builder)
    {
        throw new NotImplementedException();

        //MenuReviews
    }
}
