using Core.Application.Receipts.Common;
using Core.Application.Receipts.Items.ChangeReceiptItemQuantity;
using FluentValidation;

namespace Core.Application.Receipts.Items.ChangeReceiptItemCategory;

public sealed class ChangeReceiptItemQuantityCommandValidator : AbstractValidator<ChangeReceiptItemQuantityCommand>
{
    public ChangeReceiptItemQuantityCommandValidator()
    {
        Include(new ManipulateReceiptItemCommandValidator());
        RuleFor(cmd => cmd.NewQuantity).GreaterThan(0);
    }
}