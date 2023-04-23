using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Receipts;

public record ReceiptItemId : IdBase
{
    public ReceiptItemId(Guid guid) : base(guid) { }
}