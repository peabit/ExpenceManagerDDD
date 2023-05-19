using Core.Application.Receipts.Common;

namespace Core.Application.Rceipts.AddItemToReceipt;

public sealed record AddItemToReceiptCommand : ManipulateReceiptCommand
{
    public AddItemToReceiptCommand(string userId, string receiptId, ReceiptItemDto newItem) 
        : base(userId, receiptId)
    {
        NewItem = newItem;
    }

    public ReceiptItemDto NewItem { get; init; }
}