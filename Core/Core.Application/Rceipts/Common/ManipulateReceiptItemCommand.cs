using Core.Application.Receipts.Common;

namespace Core.Application.Rceipts.Common;

public abstract record ManipulateReceiptItemCommand : ManipulateReceiptCommand
{
    public ManipulateReceiptItemCommand(string userId, string receiptId, string itemId) 
        : base(userId, receiptId)
    {
        ItemId = itemId;
    }

    public string ItemId { get; private set; }
}