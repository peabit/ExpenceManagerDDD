namespace WebAPI.Endpoints.Categories.ChangeCategory;

public sealed record ChangeCategoryRequest(string? Name, string? ParentCategoryId);