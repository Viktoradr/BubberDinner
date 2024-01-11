using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuSectionId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique()
    {
        return new MenuSectionId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static MenuSectionId Create(string value)
    {
        return new MenuSectionId(Guid.Parse(value));
    }

    public static MenuSectionId Create(Guid value)
    {
        return new MenuSectionId(value);
    }
}
