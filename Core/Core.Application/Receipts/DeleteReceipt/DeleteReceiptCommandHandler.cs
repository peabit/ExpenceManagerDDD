using Core.Application.Common;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;

namespace Core.Application.Receipts.DeleteReceipt;

public sealed class DeleteReceiptCommandHandler : ICommandHandler<DeleteReceiptCommand>
{
    private IReceiptRepository _receiptRepository;

    public DeleteReceiptCommandHandler(IReceiptRepository receiptRepository)
       => _receiptRepository = receiptRepository;

    public async Task HandleAsync(DeleteReceiptCommand command)
        => await _receiptRepository.DeleteAsync(new User(command.UserId), new ReceiptId(command.ReceiptId));
}