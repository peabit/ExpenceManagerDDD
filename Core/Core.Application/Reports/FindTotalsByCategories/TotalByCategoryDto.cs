namespace Core.Application.Reports.FindTotalsByCategories;

public sealed record TotalByCategoryDto(string Category, decimal Total)
{
    // For Dapper
    private TotalByCategoryDto() : this(default!, default) { }
}