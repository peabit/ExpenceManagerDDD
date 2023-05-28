using Core.Application.Categories.Common;

namespace Core.Application.Categories.RenameCategory;

public sealed record RenameCategoryCommand(
    string UserId,
    string CategoryId,
    string NewName
)
: ManipulateCategoryCommand(UserId, CategoryId);