namespace Core.Application.Receipts.FindReceiptsByPeriod;

public sealed record FindReceiptsByPeriodQuery(
    string UserId,
    DateTime From,
    DateTime To
);