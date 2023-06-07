using FluentValidation;

namespace Core.Application.Receipts.Common;

public class ManipulateReceiptCommandValidator : AbstractValidator<ManipulateReceiptCommand>
{
    public ManipulateReceiptCommandValidator()
    {
        RuleFor(cmd => cmd.UserId).NotEmpty();
        RuleFor(cmd => cmd.ReceiptId).NotEmpty();
    }
}