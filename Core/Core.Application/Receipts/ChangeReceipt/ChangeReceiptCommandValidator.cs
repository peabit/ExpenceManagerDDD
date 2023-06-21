using FluentValidation;
using FluentValidation.Results;

namespace Core.Application.Receipts.ChangeReceipt;

public sealed class ChangeReceiptCommandValidator : AbstractValidator<ChangeReceiptCommand>
{
    public ChangeReceiptCommandValidator()
    {
        //RuleFor(c => c.ShopName).NotEmpty();
        //RuleFor(c => c.DateTime).NotEmpty();
    }

    //public override ValidationResult Validate(ValidationContext<ChangeReceiptCommand> context)
    
}
