using Core.Application.Rceipts.Common;

namespace Core.Application.Rceipts.ChangeReceiptItemPrice;

public sealed record ChangeReceiptItemPriceCommand : ManipulateReceiptItemCommand
{
    public ChangeReceiptItemPriceCommand(string userId, string receiptId, string itemId, decimal newPrice) 
        : base(userId, receiptId, itemId)
    {
        NewPrice = newPrice;
    }

    public decimal NewPrice { get; private init; }
}