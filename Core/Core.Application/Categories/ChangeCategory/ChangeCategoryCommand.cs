namespace Core.Application.Categories.ChangeCategory;

public sealed record ChangeCategoryCommand(
    string UserId,
    string CategoryId, 
    string? Name,
    string? ParentCategoryId
);