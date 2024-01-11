using BuberDinner.Domain.Common.Models;
using MongoDB.Bson;

namespace BuberDinner.Domain.UserAggregate.ValueObjects;

public sealed class UserId : AggregateRootId<ObjectId>//: ValueObject
{
    //public ObjectId Value { get; }
    public override ObjectId Value { get; protected set; }

    private UserId(ObjectId value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new UserId(ObjectId.GenerateNewId());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static UserId Create(string id)
    {
        return new UserId(ObjectId.Parse(id));
    }

    public static UserId Create(ObjectId id)
    {
        return new UserId(id);
    }
}