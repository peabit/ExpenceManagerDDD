using Core.Application.Receipts.Common;
using FluentValidation;

namespace Core.Application.Receipts.Items.ChangeReceiptItemCategory;

public sealed class ChangeReceiptItemCategoryCommandValidator : AbstractValidator<ChangeReceiptItemCategoryCommand>
{
    public ChangeReceiptItemCategoryCommandValidator()
    {
        Include(new ManipulateReceiptItemCommandValidator());
        RuleFor(cmd => cmd.NewCategoryId).NotEmpty();
    }
}