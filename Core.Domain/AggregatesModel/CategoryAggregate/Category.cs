using Core.Domain.AggregatesModel.UserAggregate;
using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.CategoryAggregate;

public class Category : IAggregateRoot
{
    public CategoryId Id { get; set; }
    public UserId UserId { get; set; }
    public CategoryId? ParentId { get; set; }
    public string Name { get; set; }
}