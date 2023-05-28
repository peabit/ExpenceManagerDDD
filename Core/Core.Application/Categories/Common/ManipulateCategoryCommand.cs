namespace Core.Application.Categories.Common;

public abstract record ManipulateCategoryCommand(string UserId, string CategoryId);