namespace Core.Application.Rceipts.GetReceipt;

public sealed record ReceiptItemDto
{
    public string Name { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public decimal Coast { get; init; }
    public string Category { get; init; }
}