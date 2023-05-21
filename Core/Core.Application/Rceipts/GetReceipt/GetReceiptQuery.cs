namespace Core.Application.Rceipts.GetReceipt;

public sealed record GetReceiptQuery
{
    public string UserId { get; private init; }
    public string ReceiptId { get; private init; }

    public GetReceiptQuery(string userId, string receiptId)
    {
        UserId = userId;
        ReceiptId = receiptId;
    }
}