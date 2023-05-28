using Core.Application.Categories.Common;

namespace Core.Application.Categories.LinkCategoryToParent;

public sealed record LinkCategoryToParentCommand(
    string UserId, 
    string CategoryId,
    string ParentCategoryId
)
: ManipulateCategoryCommand(UserId, CategoryId);
