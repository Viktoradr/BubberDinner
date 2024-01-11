using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;


public sealed class HostId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private HostId(Guid value)
    {
        Value = value;
    }

    //public static HostId Create(UserId userId)
    //{
    //    return new HostId($"Host_{userId}");
    //}

    public static HostId Create(string hostId)
    {
        return new HostId(Guid.Parse(hostId));
    }

    public static HostId Create(Guid hostId)
    {
        return new HostId(hostId);
    }

    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}