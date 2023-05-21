namespace Core.Application.Rceipts.FindReceiptsByPeriod;

public sealed record ReceiptDto
{
    public string Id { get; private init; }
    public string ShopName { get; private init; }
    public DateTime DateTime { get; private init; }
    public decimal Total { get; private init; }
    
    public ReceiptDto(string id, string shopName, DateTime dateTime, decimal total)
	{
        Id = id;
        ShopName = shopName;
        DateTime = dateTime;
        Total = total;
	}
}