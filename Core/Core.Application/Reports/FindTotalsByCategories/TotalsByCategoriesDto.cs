namespace Core.Application.Reports.FindTotalsByCategories;

public sealed record TotalsByCategoriesDto(
    DateTime From,
    DateTime To,
    IEnumerable<TotalByCategoryDto> Totals,
    decimal Total
);