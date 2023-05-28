using Core.Application.Common;
using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.ChangeReceiptShopName;

public sealed class ChangeReceiptShopNameCommandHandler : ICommandHandler<ChangeReceiptShopNameCommand>
{
    private ReceiptChanger _receiptChanger;

    public ChangeReceiptShopNameCommandHandler(ReceiptChanger receiptChanger)
        => _receiptChanger = receiptChanger;

    public async Task Handle(ChangeReceiptShopNameCommand command)
        => await _receiptChanger.Change(command, receipt => receipt.ChangeShopNameTo(command.NewShopName));
}