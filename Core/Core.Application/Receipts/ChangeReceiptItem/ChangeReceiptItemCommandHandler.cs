using Core.Application.Common;
using Core.Domain.AggregatesModel.Categories;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;

namespace Core.Application.Receipts.ChangeReceiptItem;

public sealed class ChangeReceiptItemCommandHandler : ICommandHandler<ChangeReceiptItemCommand>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserProvider _userProvider;

    public ChangeReceiptItemCommandHandler(IReceiptRepository receiptRepository, ICategoryRepository categoryRepository, IUserProvider userProvider)
    {
        _receiptRepository = receiptRepository ?? throw new ArgumentNullException(nameof(receiptRepository));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
    }

    public async Task HandleAsync(ChangeReceiptItemCommand command)
    {
        var user = await _userProvider.GetAsync(command.UserId);

        var receipt = await _receiptRepository.GetAsync(user, new ReceiptId(command.ReceiptId));
        var item = receipt.GetItem(new ReceiptItemId(command.ItemId));

        if (command.Name is not null)
        {
            item.ChangeNameTo(command.Name);
        }

        if (command.Price is not null)
        {
            item.ChangePriceTo(command.Price.Value);
        }

        if (command.Quantity is not null)
        {
            item.ChangeQuantityTo(command.Quantity.Value);
        }

        if (command.CategoryId is not null)
        {
            var category = await _categoryRepository.GetAsync(user, new CategoryId(command.CategoryId));
            item.ChangeCategoryTo(category);
        }
    }
}