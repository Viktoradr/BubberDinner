using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.BillAggregate;

public sealed class Bill : AggregateRoot<BillId, Guid>
{
    public Money Price { get; }

    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }

    public DateTime CreatedDateTime { get; }
    public DateTime UpdateDateTime { get; }

    private Bill(
        BillId billId,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Money price,
        DateTime createdDateTime,
        DateTime updateDateTime) : base(billId)
    {
        Price = price;
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdateDateTime = updateDateTime;
    }

    public static Bill Create(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Money price)
    {
        return new(
            BillId.CreateUnique(),
            dinnerId,
            guestId,
            hostId,
            price,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
