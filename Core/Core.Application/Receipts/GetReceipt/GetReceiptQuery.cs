namespace Core.Application.Receipts.GetReceipt;

public sealed record GetReceiptQuery(
    string UserId,
    string ReceiptId
);