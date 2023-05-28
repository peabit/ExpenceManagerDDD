namespace Core.Application.Reports.FindTotalByCategories;

public sealed record TotalByCategoryDto(string Category, decimal Total)
{
    // For Dapper
    private TotalByCategoryDto() : this(default!, default) { }
}