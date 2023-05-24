namespace Core.Application.Reports.FindTotalByCategories;

public sealed record TotalByCategoryDto
{
    public string Category { get; init; }
    public decimal Total { get; init; }
}