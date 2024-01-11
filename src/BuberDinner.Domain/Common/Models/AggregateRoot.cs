namespace BuberDinner.Domain.Common.Models;

public abstract class AggregateRoot<TId, TIdType> : Entity<TId> where TId : AggregateRootId<TIdType>
{
    public virtual new AggregateRootId<TIdType> Id { get; protected set; }
    protected AggregateRoot(TId id) {  Id = id; }

    protected AggregateRoot() { }
}

public abstract class AggregateRoot<TId> : Entity<TId> where TId : notnull
{
    protected AggregateRoot(TId id) : base(id) { }
}
