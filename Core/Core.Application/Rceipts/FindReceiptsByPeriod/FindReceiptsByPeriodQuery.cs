namespace Core.Application.Rceipts.FindReceiptsByPeriod;

public sealed record FindReceiptsByPeriodQuery
{
    public FindReceiptsByPeriodQuery(string userId, DateTime from, DateTime to)
    {
        UserId = userId;
        From = from;
        To = to;
    }

    public string UserId { get; private init; }
    public DateTime From { get; private init; }
    public DateTime To { get; private init; } 
}