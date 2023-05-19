namespace Core.Application.Rceipts.DeleteReceipt;

public sealed record DeleteReceiptCommand
{
    public DeleteReceiptCommand(string userId, string receiptId)
    {
        UserId = userId;
        ReceiptId = receiptId;
    }

    public string UserId { get; private init; }
    public string ReceiptId { get; private init; }
}