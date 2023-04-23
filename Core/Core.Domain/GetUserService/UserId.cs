using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.UserAggregate;

public record UserId : IdBase
{
	public UserId(Guid guid) : base(guid) { }
}