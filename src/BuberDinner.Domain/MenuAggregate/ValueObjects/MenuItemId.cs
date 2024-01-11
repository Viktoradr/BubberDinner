using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuItemId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new MenuItemId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static MenuItemId Create(string value)
    {
        return new MenuItemId(Guid.Parse(value));
    }

    public static MenuItemId Create(Guid value)
    {
        return new MenuItemId(value);
    }
}
