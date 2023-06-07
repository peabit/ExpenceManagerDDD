using Core.Application.Categories.Common;
using FluentValidation;

namespace Core.Application.Categories.LinkCategoryToParent;

public sealed class LinkCategoryToParentCommandValidator : AbstractValidator<LinkCategoryToParentCommand>
{
    public LinkCategoryToParentCommandValidator()
    {
        Include(new ManipulateCategoryCommandValidator());
        RuleFor(cmd => cmd.ParentCategoryId)
            .NotEmpty()
            .NotEqual(cmd => cmd.CategoryId);
    }
}