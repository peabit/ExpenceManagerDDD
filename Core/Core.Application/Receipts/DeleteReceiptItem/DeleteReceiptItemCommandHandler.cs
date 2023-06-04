using Core.Application.Common;
using Core.Application.Receipts.Common;
using Core.Domain.AggregatesModel.Receipts;

namespace Core.Application.Receipts.DeleteReceiptItem;

public sealed class DeleteReceiptItemCommandHandler : ICommandHandler<DeleteReceiptItemCommand>
{
    private readonly ReceiptChanger _receiptChanger;

    public DeleteReceiptItemCommandHandler(ReceiptChanger receiptChanger)
        => _receiptChanger = receiptChanger;

    public async Task HandleAsync(DeleteReceiptItemCommand command)
        => await _receiptChanger.Change(command, receipt => receipt.DeleteItem(new ReceiptItemId(command.ReceipItemtId)));
}