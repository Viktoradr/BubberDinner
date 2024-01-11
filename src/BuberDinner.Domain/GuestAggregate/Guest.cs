using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate;

public sealed class Guest : AggregateRoot<GuestId, Guid>
{
    private readonly List<DinnerId> _upcomingDinnerIds = new();
    private readonly List<DinnerId> _pastDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<Rating> _ratings = new();

    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public UserId UserId { get; }
    public IReadOnlyList<DinnerId> UpcomingDinners => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinners => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinners => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> Bills => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviews => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdateDateTime { get; }

    public Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        UserId userId,
        DateTime createdDateTime,
        DateTime updateDateTime) : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdateDateTime = updateDateTime;
    }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId)
    {
        return new(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
