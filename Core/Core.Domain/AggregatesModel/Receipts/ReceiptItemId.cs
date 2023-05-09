using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Receipts;

public record ReceiptItemId : EntityIdBase
{
    public ReceiptItemId(Guid guid) : base(guid) { }
    public ReceiptItemId() : base() { }
}