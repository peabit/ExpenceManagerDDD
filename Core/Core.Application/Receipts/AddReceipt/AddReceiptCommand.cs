using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.AddReceipt;

public sealed record AddReceiptCommand(
    string UserId,
    string ShopName,
    DateTime DateTime,
    IEnumerable<NewReceiptItemDto> Items
);