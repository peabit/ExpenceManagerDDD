namespace Core.Application.Rceipts.Common;

public sealed record ReceiptHeaderDto
{
    public string Id { get; init; }
    public string ShopName { get; init; }
    public DateTime DateTime { get; init; }
    public decimal Total { get; init; }
}