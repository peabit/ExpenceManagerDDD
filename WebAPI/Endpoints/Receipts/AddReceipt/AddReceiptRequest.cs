using Core.Application.Receipts.Common;

namespace WebAPI.Endpoints.Receipts.AddReceipt;

public sealed record AddReceiptRequest(
    string ShopName,
    DateTime DateTime,
    IEnumerable<NewReceiptItemDto> Items
);