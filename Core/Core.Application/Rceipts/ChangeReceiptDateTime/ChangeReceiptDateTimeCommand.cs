using Core.Application.Receipts.Common;

namespace Core.Application.Rceipts.ChangeReceiptDateTime;

public sealed record ChangeReceiptDateTimeCommand : ManipulateReceiptCommand
{
    public ChangeReceiptDateTimeCommand(string userId, string receiptId, DateTime newDateTime) 
        : base(userId, receiptId)
    {
        NewDateTime = newDateTime;
    }

    public DateTime NewDateTime { get; private init; }
}