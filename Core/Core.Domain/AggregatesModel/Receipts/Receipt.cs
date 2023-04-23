using Core.Domain.AggregatesModel.UserAggregate;
using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Receipts;

public class Receipt : IAggregateRoot
{
    public ReceiptId Id { get; set; }
    public UserId UserId { get; set; }
    public string ShopName { get; set; }
    public DateTime DateTime { get; set; }
    public decimal Total { get; set; }
    public IEnumerable<ReceiptItem> Items { get; set; }
}