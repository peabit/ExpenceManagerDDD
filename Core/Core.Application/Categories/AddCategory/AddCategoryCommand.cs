namespace Core.Application.Categories.AddCategory;

public sealed record AddCategoryCommand(
    string UserId, 
    string Name, 
    string? ParentCategoryId = null
);