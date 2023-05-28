namespace Core.Application.Categories.Common;

public sealed record CategoryDto(
    string Id,
    string Name,
    string ParentId,
    string ParentName
)
{
    // For Dapper
    private CategoryDto() : this(default!, default!, default!, default!) { }
}