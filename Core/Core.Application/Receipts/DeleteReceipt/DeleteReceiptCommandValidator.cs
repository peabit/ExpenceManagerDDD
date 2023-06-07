using FluentValidation;

namespace Core.Application.Receipts.DeleteReceipt;

public sealed class DeleteReceiptCommandValidator : AbstractValidator<DeleteReceiptCommand>
{
    public DeleteReceiptCommandValidator()
    {
        RuleFor(cmd => cmd.UserId).NotEmpty();
        RuleFor(cmd => cmd.ReceiptId).NotEmpty();
    }
}