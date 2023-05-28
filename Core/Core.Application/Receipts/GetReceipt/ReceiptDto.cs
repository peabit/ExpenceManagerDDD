using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.GetReceipt;

public sealed record ReceiptDto(
    ReceiptHeaderDto Header,
    IEnumerable<ReceiptItemDto> Items
);