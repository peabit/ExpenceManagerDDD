namespace Core.Application.Receipts.Common;

public abstract record ChangeReceiptCommandBase(
    string UserId,
    string ReceiptId
);