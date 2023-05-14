using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Receipts;

public record ReceiptItemId : EntityIdBase
{
    public ReceiptItemId(string id) : base(id) { }
    public ReceiptItemId() : base() { }
}