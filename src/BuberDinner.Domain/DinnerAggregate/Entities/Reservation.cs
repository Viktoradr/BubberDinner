using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; }
    public ReservationStatus Status { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime? ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Reservation(
        ReservationId reservationId,
        int guestCount,
        GuestId guestId,
        BillId billId,
        DateTime createdDateTime,
        DateTime updateDateTime) : base(reservationId)
    {
        GuestCount = guestCount;
        GuestId = guestId;
        BillId = billId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updateDateTime;
    }

    public static Reservation Create(int guestCount, GuestId guestId, BillId billId)
    {
        return new(
            ReservationId.CreateUnique(),
            guestCount,
            guestId, 
            billId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
