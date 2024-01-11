using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class ReservationId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private ReservationId(Guid value)
    {
        Value = value;
    }

    public static ReservationId CreateUnique()
    {
        return new ReservationId(Guid.NewGuid());
    }

    public static ReservationId Create(string value)
    {
        return new ReservationId(Guid.Parse(value));
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
