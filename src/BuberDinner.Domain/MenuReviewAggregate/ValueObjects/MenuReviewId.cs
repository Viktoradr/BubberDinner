using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

public sealed class MenuReviewId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public static MenuReviewId CreateUnique()
    {
        return new MenuReviewId(Guid.NewGuid());
    }

    public static MenuReviewId Create(string id)
    {
        return new MenuReviewId(Guid.Parse(id));
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
