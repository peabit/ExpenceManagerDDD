namespace Core.Domain.Common;

public abstract record EntityIdBase
{
    private readonly Guid _guid;

    public EntityIdBase(Guid guid)
        => _guid = guid;

    internal EntityIdBase() : this(Guid.NewGuid()) { }

    public override int GetHashCode()
        => _guid.GetHashCode();

    public override sealed string ToString()
        => _guid.ToString();
}