using Core.Application.Common;
using Core.Application.Receipts.Common;
using Core.Domain.AggregatesModel.Categories;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;

namespace Core.Application.Receipts.AddReceipt;

public sealed class AddReceiptCommandHandler : ICommandHandler<AddReceiptCommand>
{
    private readonly IUserProvider _userProvider;
    private readonly IReceiptRepository _receiptRepository;
    private readonly ICategoryProvider _categoryProvider;

    public AddReceiptCommandHandler(IUserProvider userProvider, IReceiptRepository receiptRepository, ICategoryProvider categoryProvider)
    {
        _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
        _receiptRepository = receiptRepository ?? throw new ArgumentNullException(nameof(receiptRepository));
        _categoryProvider = categoryProvider ?? throw new ArgumentNullException(nameof(categoryProvider));
    }

    public async Task HandleAsync(AddReceiptCommand command)
    {
        var user = await _userProvider.GetAsync(command.UserId);
        var items = await CreateItems(user, command.Items);
        var receipt = user.CreateReceipt(command.ShopName, command.DateTime, items);
        await _receiptRepository.AddAsync(receipt);
    }

    private async Task<IEnumerable<ReceiptItem>> CreateItems(User user, IEnumerable<NewReceiptItemDto> itemDtos)
    {
        var items = new List<ReceiptItem>();

        foreach (var itemDto in itemDtos)
        {
            var category = await _categoryProvider.GetAsync(user, new CategoryId(itemDto.CategoryId));
            var item = category.CreateReceiptItem(itemDto.Name, itemDto.Price, itemDto.Quantity);
            items.Add(item);
        }

        return items;
    }
}