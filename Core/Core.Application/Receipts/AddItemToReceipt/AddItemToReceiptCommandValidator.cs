using Core.Application.Receipts.Common;
using FluentValidation;

namespace Core.Application.Receipts.AddItemToReceipt;

public sealed class AddItemToReceiptCommandValidator : AbstractValidator<AddItemToReceiptCommand>
{
    public AddItemToReceiptCommandValidator()
    {
        //Include(new ManipulateReceiptCommandValidator());
        RuleFor(cmd => cmd.NewItem).SetValidator(new NewReceiptItemDtoValidator());
    }
}