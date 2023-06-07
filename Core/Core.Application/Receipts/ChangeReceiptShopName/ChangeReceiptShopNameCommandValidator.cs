using Core.Application.Receipts.ChangeReceiptShopName;
using Core.Application.Receipts.Common;
using FluentValidation;

namespace Core.Application.Receipts.ChangeReceiptDateTime;

public sealed class ChangeReceiptShopNameCommandValidator : AbstractValidator<ChangeReceiptShopNameCommand>
{
    public ChangeReceiptShopNameCommandValidator()
    {
        Include(new ManipulateReceiptCommandValidator());
        RuleFor(cmd => cmd.NewShopName).NotEmpty();
    }
}