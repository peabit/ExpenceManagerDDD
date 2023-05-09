using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Users;

public record UserId : EntityIdBase
{
	public UserId() { }
    public UserId(Guid guid) : base(guid) { }
}