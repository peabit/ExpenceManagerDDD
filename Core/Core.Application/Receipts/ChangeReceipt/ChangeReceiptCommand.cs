using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.ChangeReceipt;

public sealed record ChangeReceiptCommand(
    string UserId,
    string ReceiptId, 
    string? ShopName,
    DateTime? DateTime
)
: Common.ChangeReceiptCommandBase(UserId, ReceiptId);