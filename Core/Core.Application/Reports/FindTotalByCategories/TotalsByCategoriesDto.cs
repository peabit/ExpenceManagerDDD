namespace Core.Application.Reports.FindTotalByCategories;

public sealed record TotalsByCategoriesDto
{
    public TotalsByCategoriesDto(DateTime from, DateTime to, IEnumerable<TotalByCategoryDto> totals)
    {
        From = from;
        To = to;
        Totals = totals;
    }

    public DateTime From { get; init; }
    public DateTime To { get; init; }
    IEnumerable<TotalByCategoryDto> Totals { get; init; } 
}