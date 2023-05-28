using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.CreateReceipt;

public sealed record CreateReceiptCommand(
    string UserId,
    string ShopName,
    DateTime DateTime,
    IEnumerable<NewReceiptItemDto> Items
);