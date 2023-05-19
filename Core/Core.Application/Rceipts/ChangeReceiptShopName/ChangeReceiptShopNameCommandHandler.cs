using Core.Application.Rceipts.Common;
using Core.Domain.AggregatesModel.Receipts;

namespace Core.Application.Rceipts.ChangeReceiptShopName;

public sealed class ChangeReceiptShopNameCommandHandler
{
    private IReceiptRepository _receiptRepository;

    public ChangeReceiptShopNameCommandHandler(IReceiptRepository receiptRepository) =>
        _receiptRepository = receiptRepository;

    public async Task ChangeReceiptShopName(ChangeReceiptShopNameCommand command)
    {
        var receipt = await _receiptRepository.GetForManipulateCommandAsync(command);
        receipt.ChangeShopNameTo(command.NewShopName);
        await _receiptRepository.UpdateAsync(receipt);
    }
}