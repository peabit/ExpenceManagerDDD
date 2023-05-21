using Core.Application.Common;
using Core.Application.Rceipts.Common;

namespace Core.Application.Rceipts.ChangeReceiptItemPrice;

public class ChangeReceiptItemPriceCommandHandler : ICommandHandler<ChangeReceiptItemPriceCommand>
{
    private readonly ReceiptItemChanger _receiptItemChanger;

    public ChangeReceiptItemPriceCommandHandler(ReceiptItemChanger receiptItemChanger)
        => _receiptItemChanger = receiptItemChanger;

    public async Task Handle(ChangeReceiptItemPriceCommand command)
        => await _receiptItemChanger.Change(command, item => item.ChangePriceTo(command.NewPrice));
}