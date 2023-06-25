namespace Core.Domain.Common;

public abstract class EntityBase<TId>
     where TId : EntityIdBase, new()
{
    protected EntityBase(TId? id = null)
    {
        Id = id ?? new TId();
    }
    
    public TId Id { get; private init; }
}