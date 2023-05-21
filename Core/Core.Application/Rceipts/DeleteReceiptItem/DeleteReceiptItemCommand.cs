using Core.Application.Receipts.Common;

namespace Core.Application.Rceipts.DeleteReceiptItem;

public sealed record DeleteReceiptItemCommand : ManipulateReceiptCommand
{
    public DeleteReceiptItemCommand(string userId, string receiptId, string receipItemtId) 
        : base(userId, receiptId)
    {
        ReceiptItemId = receipItemtId;
    }

    public string ReceiptItemId { get; private init; }
}