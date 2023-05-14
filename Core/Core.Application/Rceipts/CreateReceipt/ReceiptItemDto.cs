namespace Core.Application.Rceipts.CreateReceipt;

public sealed record ReceiptItemDto
{
    public ReceiptItemDto(string categoryId, string name, decimal price, int quantity)
    {
        CategoryId = categoryId;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public string CategoryId { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

}