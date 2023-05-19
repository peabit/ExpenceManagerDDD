using Core.Application.Receipts.Common;

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

    public string UserId { get; private init; }
    public string ShopName { get; private init; }
    public DateTime DateTime { get; private init; }
    public IEnumerable<ReceiptItemDto> Items { get; private init; }
}