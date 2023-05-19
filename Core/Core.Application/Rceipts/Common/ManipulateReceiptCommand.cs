namespace Core.Application.Receipts.Common;

public abstract record ManipulateReceiptCommand
{
    protected ManipulateReceiptCommand(string userId, string receiptId)
    {
        UserId = userId;
        ReceiptId = receiptId;
    }

    public string UserId { get; private init; }
    public string ReceiptId { get; private init; }
}