using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.ChangeReceiptItem;

public sealed record ChangeReceiptItemCommand(
    string UserId,
    string ReceiptId,
    string ItemId,
    string? CategoryId,
    string? Name,
    decimal? Price,
    int? Quantity
)
: ChangeReceiptCommandBase(UserId, ReceiptId);