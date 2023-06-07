using Core.Application.Categories.Common;
using FluentValidation;

namespace Core.Application.Categories.UnlinkCategoryFromParent;

public sealed class UnlinkCategoryFromParentCommandValidator : AbstractValidator<UnlinkCategoryFromParentCommand>
{
    public UnlinkCategoryFromParentCommandValidator()
        => Include(new ManipulateCategoryCommandValidator());
}