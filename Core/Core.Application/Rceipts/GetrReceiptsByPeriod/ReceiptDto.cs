namespace Core.Application.Rceipts.GetUserReceipts;

public sealed record ReceiptDto
{
    public Guid Id { get; private set; }
    public string ShopName { get; private set; }
    public DateTime DateTime { get; private set; }
    public decimal Total { get; private set; }
    
    internal ReceiptDto(Guid id, string shopName, DateTime dateTime, decimal total)
	{
        Id = id;
        ShopName = shopName;
        DateTime = dateTime;
        Total = total;
	}
}