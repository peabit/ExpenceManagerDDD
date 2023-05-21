using Core.Application.Common;
using Core.Application.Rceipts.Common;

namespace Core.Application.Rceipts.ChangeReceiptDateTime;

public sealed class ChangeReceiptDateTimeCommandHandler : ICommandHandler<ChangeReceiptDateTimeCommand>
{
    private readonly ReceiptChanger _changer;

    public ChangeReceiptDateTimeCommandHandler(ReceiptChanger changer)
        => _changer = changer;

    public async Task Handle(ChangeReceiptDateTimeCommand command)
        => await _changer.Change(command, receipt => receipt.ChangeDateTimeTo(command.NewDateTime));
}