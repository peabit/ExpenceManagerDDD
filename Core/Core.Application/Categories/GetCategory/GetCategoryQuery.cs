namespace Core.Application.Categories.GetCategory;

public sealed record GetCategoryQuery(
    string UserId, 
    string CategoryId
);