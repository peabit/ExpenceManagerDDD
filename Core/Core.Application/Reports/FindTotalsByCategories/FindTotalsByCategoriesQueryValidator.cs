using FluentValidation;

namespace Core.Application.Reports.FindTotalsByCategories;

public sealed class FindTotalsByCategoriesQueryValidator : AbstractValidator<FindTotalsByCategoriesQuery>
{
    public FindTotalsByCategoriesQueryValidator()
    {
        RuleFor(q => q.UserId).NotEmpty();
        RuleFor(q => q.CategoryIds).NotEmpty();
    }
}