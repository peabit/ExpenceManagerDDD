using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Categories;

public record CategoryId : EntityIdBase
{
    public CategoryId(Guid guid) : base(guid) { }
    public CategoryId() : base() { }
}