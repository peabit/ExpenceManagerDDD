using Core.Application.Receipts.Common;
using Core.Application.Receipts.Items.RenameReceiptItem;
using FluentValidation;

namespace Core.Application.Receipts.Items.ChangeReceiptItemCategory;

public sealed class RenameReceiptItemCommandValidator : AbstractValidator<RenameReceiptItemCommand>
{
    public RenameReceiptItemCommandValidator()
    {
        Include(new ManipulateReceiptItemCommandValidator());
        RuleFor(cmd => cmd.NewName).NotEmpty();
    }
}