using Core.Application.Rceipts.Common;
using Core.Application.Receipts.Common;

namespace Core.Application.Rceipts.GetReceipt;

public sealed record ReceiptDto
{
    public ReceiptDto(ReceiptHeaderDto header, IEnumerable<ReceiptItemDto> items)
    {
        Header = header;
        Items = items;
    }

    public ReceiptHeaderDto Header { get; private init; }
    public IEnumerable<ReceiptItemDto> Items { get; private init; }
}