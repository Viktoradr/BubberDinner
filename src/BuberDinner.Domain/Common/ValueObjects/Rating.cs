using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public int Value { get; }
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdateDateTime { get; }

    private Rating(
        int rating, 
        HostId hostId, 
        DinnerId dinnerId, 
        DateTime createdDateTime, 
        DateTime updateDateTime)
    {
        Value = rating;
        HostId = hostId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdateDateTime = updateDateTime;
    }

    public static Rating CreateNew(
        int rating,
        HostId hostId,
        DinnerId dinnerId)
    {
        return new Rating(
            rating,
            hostId,
            dinnerId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return HostId;
        yield return DinnerId;
        yield return CreatedDateTime;
        yield return UpdateDateTime;
    }
}
