using FluentValidation;

namespace Core.Application.Categories.GetCategory;

public sealed class GetCategoryQueryValidator : AbstractValidator<GetCategoryQuery>
{
    public GetCategoryQueryValidator()
    {
        RuleFor(q => q.UserId).NotEmpty();
        RuleFor(q => q.CategoryId).NotEmpty();  
    }
}