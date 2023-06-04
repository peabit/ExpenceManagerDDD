using Core.Application.Common;
using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.ChangeReceiptDateTime;

public sealed class ChangeReceiptDateTimeCommandHandler : ICommandHandler<ChangeReceiptDateTimeCommand>
{
    private readonly ReceiptChanger _changer;

    public ChangeReceiptDateTimeCommandHandler(ReceiptChanger changer)
        => _changer = changer;

    public async Task HandleAsync(ChangeReceiptDateTimeCommand command)
        => await _changer.Change(command, receipt => receipt.ChangeDateTimeTo(command.NewDateTime));
}