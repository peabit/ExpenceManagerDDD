using Core.Application.Rceipts.Common;

namespace Core.Application.Rceipts.RenameReceiptItem;

public sealed record RenameReceiptItemCommand : ManipulateReceiptItemCommand
{
    public RenameReceiptItemCommand(string userId, string receiptId, string itemId, string newName) 
        : base(userId, receiptId, itemId)
    {
        NewName = newName;
    }

    public string NewName { get; private init; }
}