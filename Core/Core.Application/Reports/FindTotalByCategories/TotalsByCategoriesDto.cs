namespace Core.Application.Reports.FindTotalByCategories;

public sealed record TotalsByCategoriesDto(
    DateTime From,
    DateTime To,
    IEnumerable<TotalByCategoryDto> Totals
);