using FluentValidation;

namespace Core.Application.Receipts.FindReceiptsByPeriod;

public sealed class FindReceiptsByPeriodQueryValidator : AbstractValidator<FindReceiptsByPeriodQuery>
{
    public FindReceiptsByPeriodQueryValidator()
    {
        RuleFor(q => q.UserId).NotEmpty();
    }
}