using Core.Application.Common;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;

namespace Core.Application.Receipts.DeleteReceipt;

public sealed class DeleteReceiptCommandHandler : ICommandHandler<DeleteReceiptCommand>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IUserProvider _userProvider;

    public DeleteReceiptCommandHandler(IReceiptRepository receiptRepository, IUserProvider userProvider)
    {
        _receiptRepository = receiptRepository ?? throw new ArgumentNullException(nameof(receiptRepository));
        _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
    }

    public async Task HandleAsync(DeleteReceiptCommand command)
    {
        var user = await _userProvider.GetAsync(command.UserId);
        var receipt = await _receiptRepository.GetAsync(user, new ReceiptId(command.ReceiptId));
        _receiptRepository.Delete(receipt);
    }
}