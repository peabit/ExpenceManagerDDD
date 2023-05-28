using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.DeleteReceiptItem;

public sealed record DeleteReceiptItemCommand(
    string UserId,
    string ReceiptId,
    string ReceipItemtId
)
: ManipulateReceiptCommand(UserId, ReceiptId);