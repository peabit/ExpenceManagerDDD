using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Categories;

public record CategoryId : IdBase
{
	public CategoryId(Guid guid) : base(guid) { }
}