namespace Core.Application.Reports.FindTotalByCategories;

public sealed record FindTotalsByCategoriesQuery(
    string UserId,
    DateTime From,
    DateTime To,
    IEnumerable<string> CategoryIds
);