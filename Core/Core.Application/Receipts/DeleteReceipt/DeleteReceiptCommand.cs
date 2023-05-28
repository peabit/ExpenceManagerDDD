namespace Core.Application.Receipts.DeleteReceipt;

public sealed record DeleteReceiptCommand(
    string UserId,
    string ReceiptId
);