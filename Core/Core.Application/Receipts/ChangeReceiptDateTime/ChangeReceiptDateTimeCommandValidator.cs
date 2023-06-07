using Core.Application.Receipts.Common;
using FluentValidation;

namespace Core.Application.Receipts.ChangeReceiptDateTime;

public sealed class ChangeReceiptDateTimeCommandValidator : AbstractValidator<ChangeReceiptDateTimeCommand>
{
    public ChangeReceiptDateTimeCommandValidator()
    {
        Include(new ManipulateReceiptCommandValidator());
        RuleFor(cmd => cmd.NewDateTime).NotEmpty();
    }
}