namespace Core.Application.Receipts.Common;

public abstract record ManipulateReceiptItemCommand(
    string UserId,
    string ReceiptId,
    string ItemId
) 
: ManipulateReceiptCommand(UserId, ReceiptId);