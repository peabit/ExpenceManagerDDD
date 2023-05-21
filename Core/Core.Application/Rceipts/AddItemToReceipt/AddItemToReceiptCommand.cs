using Core.Application.Receipts.Common;

namespace Core.Application.Rceipts.AddItemToReceipt;

public sealed record AddItemToReceiptCommand : ManipulateReceiptCommand
{
    public AddItemToReceiptCommand(string userId, string receiptId, NewReceiptItemDto newItem) 
        : base(userId, receiptId)
    {
        NewItem = newItem;
    }

    public NewReceiptItemDto NewItem { get; init; }
}