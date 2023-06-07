using Core.Application.Receipts.Common;
using FluentValidation;

namespace Core.Application.Receipts.AddReceipt;

public sealed class AddReceiptCommandValidator : AbstractValidator<AddReceiptCommand>
{
    public AddReceiptCommandValidator()
    {
        RuleFor(cmd => cmd.UserId).NotEmpty();
        RuleFor(cmd => cmd.ShopName).NotEmpty();
        RuleFor(cmd => cmd.DateTime).NotEmpty();
        
        RuleForEach(cmd => cmd.Items)
            .NotEmpty()
            .SetValidator(new NewReceiptItemDtoValidator());
    }
}