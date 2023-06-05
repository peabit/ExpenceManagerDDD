using FluentValidation;

namespace Core.Application.Receipts.GetReceipt;

public sealed class GetReceiptQueryValidator : AbstractValidator<GetReceiptQuery>
{
    public GetReceiptQueryValidator()
    {
        RuleFor(q => q.UserId).NotEmpty();
        RuleFor(q => q.ReceiptId).NotEmpty();
    }
}