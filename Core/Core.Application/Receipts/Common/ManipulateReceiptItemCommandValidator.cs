using FluentValidation;

namespace Core.Application.Receipts.Common;

public sealed class ManipulateReceiptItemCommandValidator : AbstractValidator<ManipulateReceiptItemCommand>
{
    public ManipulateReceiptItemCommandValidator()
    {
        RuleFor(cmd => cmd.UserId).NotEmpty();
        RuleFor(cmd => cmd.ReceiptId).NotEmpty();
        RuleFor(cmd => cmd.ItemId).NotEmpty();
    }
}