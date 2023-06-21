namespace Core.Application.Reports.FindTotalsByCategories;

public sealed record TotalByCategoryDto(string Category, decimal Total, decimal SharePercent)
{
    // For Dapper
    private TotalByCategoryDto() : this(default!, default, default) { }
}