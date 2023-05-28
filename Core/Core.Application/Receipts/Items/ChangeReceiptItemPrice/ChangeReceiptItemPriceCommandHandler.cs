using Core.Application.Common;
using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.Items.ChangeReceiptItemPrice;

public class ChangeReceiptItemPriceCommandHandler : ICommandHandler<ChangeReceiptItemPriceCommand>
{
    private readonly ReceiptItemChanger _receiptItemChanger;

    public ChangeReceiptItemPriceCommandHandler(ReceiptItemChanger receiptItemChanger)
        => _receiptItemChanger = receiptItemChanger;

    public async Task Handle(ChangeReceiptItemPriceCommand command)
        => await _receiptItemChanger.Change(command, item => item.ChangePriceTo(command.NewPrice));
}