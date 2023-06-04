using Core.Application.Receipts.Common;

namespace WebAPI.Receipts;

public sealed record AddReceiptRequest(
    string ShopName,
    DateTime DateTime,
    IEnumerable<NewReceiptItemDto> Items
);