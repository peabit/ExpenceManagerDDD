using Core.Application.Rceipts.Common;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;

namespace Core.Application.Rceipts.ChangeReceiptDateTime;

public sealed class ChangeReceiptDateTimeCommandHandler
{
    private readonly IReceiptRepository _receiptRepository;

    public ChangeReceiptDateTimeCommandHandler(IReceiptRepository receiptRepository) =>
        _receiptRepository = receiptRepository;

    public async Task Handle(ChangeReceiptDateTimeCommand command)
    {
        var receipt = await _receiptRepository.GetForManipulateCommandAsync(command);
        receipt.ChangeDateTimeTo(command.NewDateTime);
        await _receiptRepository.UpdateAsync(receipt);
    }
}