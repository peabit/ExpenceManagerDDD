namespace Core.Application.Categories.DeleteCategory;

public sealed record DeleteCategoryCommand(
    string UserId, 
    string CategoryId
);