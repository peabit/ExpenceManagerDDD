namespace Core.Domain.Common;

public abstract class EntityBase<TId>
     where TId : EntityIdBase, new()
{
    private readonly TId _id;
    protected EntityBase() => _id = new TId();
    public TId Id => _id;
}