using Core.Application.Receipts.Common;
using FluentValidation;

namespace Core.Application.Receipts.DeleteReceiptItem;

public sealed class DeleteReceiptItemCommandValidator : AbstractValidator<DeleteReceiptItemCommand>
{
    public DeleteReceiptItemCommandValidator()
    {
        //Include(new ManipulateReceiptCommandValidator());
        RuleFor(cmd => cmd.ReceipItemtId).NotEmpty();
    }
}