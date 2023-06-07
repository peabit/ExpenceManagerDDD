using FluentValidation;

namespace Core.Application.Categories.Common;

public sealed class ManipulateCategoryCommandValidator : AbstractValidator<ManipulateCategoryCommand>
{
    public ManipulateCategoryCommandValidator()
    {
        RuleFor(cmd => cmd.UserId).NotEmpty();
        RuleFor(cmd => cmd.CategoryId).NotEmpty();
    }
}