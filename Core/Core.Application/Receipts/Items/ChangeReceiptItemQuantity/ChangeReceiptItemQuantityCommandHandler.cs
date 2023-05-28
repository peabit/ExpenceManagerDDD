using Core.Application.Common;
using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.Items.ChangeReceiptItemQuantity;

public sealed class ChangeReceiptItemQuantityCommandHandler : ICommandHandler<ChangeReceiptItemQuantityCommand>
{
    private readonly ReceiptItemChanger _receiptItemChanger;

    public ChangeReceiptItemQuantityCommandHandler(ReceiptItemChanger receiptItemChanger)
        => _receiptItemChanger = receiptItemChanger;

    public Task Handle(ChangeReceiptItemQuantityCommand command)
        => _receiptItemChanger.Change(command, item => item.ChangeQuantityTo(command.NewQuantity));
}