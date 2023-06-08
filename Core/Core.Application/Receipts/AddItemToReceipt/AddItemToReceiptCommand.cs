using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.AddItemToReceipt;

public sealed record AddItemToReceiptCommand(
    string UserId, 
    string ReceiptId, 
    NewReceiptItemDto NewItem
) 
: ChangeReceiptCommandBase(UserId, ReceiptId);