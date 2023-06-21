using Core.Application.Common;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;

namespace Core.Application.Receipts.DeleteReceiptItem;

public sealed class DeleteReceiptItemCommandHandler : ICommandHandler<DeleteReceiptItemCommand>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IUserProvider _userProvider;

    public DeleteReceiptItemCommandHandler(IReceiptRepository receiptRepository, IUserProvider userProvider)
    {
        _receiptRepository = receiptRepository ?? throw new ArgumentNullException(nameof(receiptRepository));
        _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
    }

    public async Task HandleAsync(DeleteReceiptItemCommand command)
    {
        var user = await _userProvider.GetAsync(command.UserId);

        var receipt = await _receiptRepository.GetAsync(user, new ReceiptId(command.ReceiptId));
        
        receipt.DeleteItem(new ReceiptItemId(command.ReceipItemtId));
    }
}