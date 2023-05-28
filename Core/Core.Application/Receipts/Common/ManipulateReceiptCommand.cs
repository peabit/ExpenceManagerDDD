namespace Core.Application.Receipts.Common;

public abstract record ManipulateReceiptCommand(
    string UserId,
    string ReceiptId
);