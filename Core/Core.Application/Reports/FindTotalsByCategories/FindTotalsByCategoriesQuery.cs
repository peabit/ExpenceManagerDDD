namespace Core.Application.Reports.FindTotalsByCategories;

public sealed record FindTotalsByCategoriesQuery(
    string UserId,
    DateTime From,
    DateTime To,
    IEnumerable<string> CategoryIds
);