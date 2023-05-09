using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Receipts;

public record ReceiptId : EntityIdBase
{
    public ReceiptId() { }
    public ReceiptId(Guid guid) : base(guid) { }
}