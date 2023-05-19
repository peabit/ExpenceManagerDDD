using Core.Application.Receipts.Common;

namespace Core.Application.Rceipts.ChangeReceiptShopName;

public sealed record ChangeReceiptShopNameCommand : ManipulateReceiptCommand
{
    public ChangeReceiptShopNameCommand(string userId, string receiptId, string newShopName) : base(userId, receiptId)
    {
        NewShopName = newShopName;
    }

    public string NewShopName { get; private init; }
}