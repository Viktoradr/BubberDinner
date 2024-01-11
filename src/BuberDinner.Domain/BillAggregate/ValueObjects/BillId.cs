using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.BillAggregate.ValueObjects;

public sealed class BillId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private BillId(Guid value)
    {
        Value = value;
    }

    public static BillId CreateUnique()
    {
        return new BillId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static BillId Create(string value)
    {
        return new BillId(Guid.Parse(value));
    }

    public static BillId Create(Guid value)
    {
        return new BillId(value);
    }
}