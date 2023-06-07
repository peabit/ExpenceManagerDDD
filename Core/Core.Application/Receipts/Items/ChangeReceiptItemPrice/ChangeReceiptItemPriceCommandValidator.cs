using Core.Application.Receipts.Common;
using Core.Application.Receipts.Items.ChangeReceiptItemPrice;
using FluentValidation;

namespace Core.Application.Receipts.Items.ChangeReceiptItemCategory;

public sealed class ChangeReceiptItemPriceCommandValidator : AbstractValidator<ChangeReceiptItemPriceCommand>
{
    public ChangeReceiptItemPriceCommandValidator()
    {
        Include(new ManipulateReceiptItemCommandValidator());
        RuleFor(cmd => cmd.NewPrice).GreaterThanOrEqualTo(0);
    }
}