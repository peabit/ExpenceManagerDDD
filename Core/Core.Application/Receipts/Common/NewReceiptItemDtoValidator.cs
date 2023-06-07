using FluentValidation;

namespace Core.Application.Receipts.Common;

public sealed class NewReceiptItemDtoValidator : AbstractValidator<NewReceiptItemDto>
{
    public NewReceiptItemDtoValidator()
    {
        RuleFor(i => i.CategoryId).NotEmpty();
        RuleFor(i => i.Name).NotEmpty();
        RuleFor(i => i.Price).GreaterThanOrEqualTo(0);
        RuleFor(i => i.Quantity).GreaterThan(0);
    }
}