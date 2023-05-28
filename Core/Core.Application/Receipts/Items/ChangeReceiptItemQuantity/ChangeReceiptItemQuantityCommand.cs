using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.Items.ChangeReceiptItemQuantity;

public sealed record ChangeReceiptItemQuantityCommand(
    string UserId,
    string ReceiptId,
    string ItemId,
    int NewQuantity
)
: ManipulateReceiptItemCommand(UserId, ReceiptId, ItemId);