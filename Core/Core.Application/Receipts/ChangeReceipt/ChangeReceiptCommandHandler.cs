using Core.Application.Common;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;

namespace Core.Application.Receipts.ChangeReceipt;

public sealed class ChangeReceiptCommandHandler : ICommandHandler<ChangeReceiptCommand>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IUserProvider _userProvider;

    public ChangeReceiptCommandHandler(IReceiptRepository receiptRepository, IUserProvider userProvider)
    {
        _receiptRepository = receiptRepository ?? throw new ArgumentNullException(nameof(receiptRepository));
        _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
    }

    public async Task HandleAsync(ChangeReceiptCommand command)
    {
        var user = await _userProvider.GetAsync(command.UserId);
        var receipt = await _receiptRepository.GetAsync(user, new ReceiptId(command.ReceiptId));

        if (command.ShopName is not null)
        {
            receipt.ChangeShopNameTo(command.ShopName);
        }

        if (command.DateTime is not null)
        {
            receipt.ChangeDateTimeTo(command.DateTime.Value);
        }
    }
}