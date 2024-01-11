using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuReviewAggregate;

public sealed class MenuReview : AggregateRoot<MenuReviewId, Guid>
{
    public Rating Rating { get; }
    public string Comment { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdateDateTime { get; }

    private MenuReview() { }

    private MenuReview(
       MenuReviewId menuReviewId,
       string comment,
       Rating rating,
       HostId hostId,
       MenuId menuId,
       GuestId guestId,
       DinnerId dinnerId,
       DateTime createdDateTime,
       DateTime updateDateTime) : base(menuReviewId)
    {
        Comment = comment;
        Rating = rating;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdateDateTime = updateDateTime;
    }

    public static MenuReview Create(
        string comment,
        Rating rating,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId)
    {
        return new(
            MenuReviewId.CreateUnique(),
            comment,
            rating,
            hostId,
            menuId, 
            guestId,
            dinnerId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
