namespace Core.Application.Receipts.GetReceipt;

public sealed record ReceiptItemDto(
    string Id, 
    string Name, 
    decimal Price,
    int Quantity, 
    decimal Coast, 
    string Category
)
{
    // For Dapper
    private ReceiptItemDto() : this(default!, default!, default, default, default, default!) { }
}