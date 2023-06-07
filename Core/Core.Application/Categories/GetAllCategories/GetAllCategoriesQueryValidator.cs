using Core.Application.Categories.Common;
using FluentValidation;

namespace Core.Application.Categories.GetAllCategories;

public sealed class GetAllCategoriesQueryValidator : AbstractValidator<GetAllCategoriesQuery>
{
    public GetAllCategoriesQueryValidator()
    {
        RuleFor(q => q.UserId).NotEmpty();
    }
}