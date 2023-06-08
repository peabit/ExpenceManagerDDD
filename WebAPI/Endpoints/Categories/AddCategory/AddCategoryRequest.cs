namespace WebAPI.Endpoints.Categories.AddCategory;

public sealed record AddCategoryRequest(string Name, string? ParentCategoryId);