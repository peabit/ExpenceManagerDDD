namespace Core.Application.Rceipts.CreateReceipt;

public sealed record CreateReceiptCommand
{
    public CreateReceiptCommand(string userId, string shopName, DateTime dateTime, IEnumerable<ReceiptItemDto> items)
    {
        UserId = userId;
        ShopName = shopName;
        DateTime = dateTime;
        Items = items;
    }

    public string UserId { get; private set; }
    public string ShopName { get; private set; }
    public DateTime DateTime { get; private set; }
    public IEnumerable<ReceiptItemDto> Items { get; private set; }
}