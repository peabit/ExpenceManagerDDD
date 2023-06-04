﻿using Core.Application.Common;
using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.Items.RenameReceiptItem;

public sealed class RenameReceiptItemCommandHandler : ICommandHandler<RenameReceiptItemCommand>
{
    private readonly ReceiptItemChanger _receiptItemChanger;

    public RenameReceiptItemCommandHandler(ReceiptItemChanger receiptItemChanger)
        => _receiptItemChanger = receiptItemChanger;

    public async Task HandleAsync(RenameReceiptItemCommand command)
        => await _receiptItemChanger.Change(command, item => item.ChangeNameTo(command.NewName));
}