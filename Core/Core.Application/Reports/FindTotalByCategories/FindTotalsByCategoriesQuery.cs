namespace Core.Application.Reports.FindTotalByCategories;

public sealed record FindTotalsByCategoriesQuery
{
    public FindTotalsByCategoriesQuery(string userId, DateTime from, DateTime to, IEnumerable<string> categoryIds)
    {
        UserId = userId;
        From = from;
        To = to;
        CategoryIds = categoryIds;
    }

    public string UserId { get; private init; }
    public DateTime From { get; private init; }
    public DateTime To { get; private init; }
    public IEnumerable<string> CategoryIds { get; private init; }
}