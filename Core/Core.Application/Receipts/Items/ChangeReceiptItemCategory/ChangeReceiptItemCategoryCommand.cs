using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.Items.ChangeReceiptItemCategory;

public sealed record ChangeReceiptItemCategoryCommand(
    string UserId,
    string ReceiptId,
    string ItemId,
    string NewCategoryId
)
: ManipulateReceiptItemCommand(UserId, ReceiptId, ItemId);