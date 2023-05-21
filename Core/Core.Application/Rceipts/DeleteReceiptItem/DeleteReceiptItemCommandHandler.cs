using Core.Application.Common;
using Core.Application.Rceipts.Common;
using Core.Domain.AggregatesModel.Receipts;

namespace Core.Application.Rceipts.DeleteReceiptItem;

public sealed class DeleteReceiptItemCommandHandler : ICommandHandler<DeleteReceiptItemCommand>
{
    private readonly ReceiptChanger _receiptChanger;

    public DeleteReceiptItemCommandHandler(ReceiptChanger receiptChanger)
        => _receiptChanger = receiptChanger;

    public async Task Handle(DeleteReceiptItemCommand command)
        => await _receiptChanger.Change(command, receipt => receipt.DeleteItem(new ReceiptItemId(command.ReceiptItemId)));
}