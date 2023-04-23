using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Receipts;

public record ReceiptId : IdBase
{
    public ReceiptId(Guid guid) : base(guid) { }
}