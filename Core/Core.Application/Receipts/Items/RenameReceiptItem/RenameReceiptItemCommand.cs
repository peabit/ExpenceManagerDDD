using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.Items.RenameReceiptItem;

public sealed record RenameReceiptItemCommand(
    string UserId,
    string ReceiptId,
    string ItemId,
    string NewName
)
: ManipulateReceiptItemCommand(UserId, ReceiptId, ItemId);