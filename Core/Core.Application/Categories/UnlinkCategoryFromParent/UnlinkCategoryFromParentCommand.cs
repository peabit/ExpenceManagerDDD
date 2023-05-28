using Core.Application.Categories.Common;

namespace Core.Application.Categories.UnlinkCategoryFromParent;

public sealed record UnlinkCategoryFromParentCommand(
    string UserId,
    string CategoryId
)
: ManipulateCategoryCommand(UserId, CategoryId);