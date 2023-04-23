namespace Core.Domain.Common;

public record IdBase
{
    private readonly Guid _guid;

    public IdBase(Guid guid)
        => _guid = guid;
    public override int GetHashCode()
        => _guid.GetHashCode();
    
    // In records this method doesn`t inherit therefore all childs will have own auto
    // generated realization. But if this method is sealed, their realization will be same for all childs.
    public override sealed string ToString()
        => _guid.ToString();
}