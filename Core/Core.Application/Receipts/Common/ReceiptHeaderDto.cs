namespace Core.Application.Receipts.Common;

public sealed record ReceiptHeaderDto(
    string Id,
    string ShopName,
    DateTime DateTime,
    decimal Total
)
{
    // For Dapper
    private ReceiptHeaderDto() : this(default!, default!, default, default) { }
}