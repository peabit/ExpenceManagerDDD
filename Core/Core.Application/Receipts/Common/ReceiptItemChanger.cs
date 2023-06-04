using Core.Domain.AggregatesModel.Receipts;

namespace Core.Application.Receipts.Common;

public class ReceiptItemChanger
{
    private readonly ReceiptChanger _receiptChanger;

    public ReceiptItemChanger(ReceiptChanger receiptChanger)
        => _receiptChanger = receiptChanger;

    public async Task Change<TCommand>(TCommand command, Action<ReceiptItem> action)
        where TCommand : ManipulateReceiptItemCommand
    {
        await _receiptChanger.Change(command, receipt =>
        {
            var item = receipt.GetItem(new ReceiptItemId(command.ItemId));
            action(item);
        });
    }
}