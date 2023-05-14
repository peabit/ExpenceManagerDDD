namespace Core.Domain.Common;

public abstract record EntityIdBase
{
    private readonly Guid _guid;

    public EntityIdBase(string id)
        => _guid = new Guid(id);

    internal EntityIdBase() 
        => _guid = Guid.NewGuid();

    public override int GetHashCode()
        => _guid.GetHashCode();

    public override sealed string ToString()
        => _guid.ToString();
}