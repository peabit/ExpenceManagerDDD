using Core.Application.Categories.Common;
using Core.Application.Categories.RenameCategory;
using FluentValidation;

namespace Core.Application.Categories.LinkCategoryToParent;

public sealed class RenameCategoryCommandValidator : AbstractValidator<RenameCategoryCommand>
{
    public RenameCategoryCommandValidator()
    {
        Include(new ManipulateCategoryCommandValidator());
        RuleFor(cmd => cmd.NewName).NotEmpty();
    }
}