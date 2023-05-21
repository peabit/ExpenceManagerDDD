using Core.Domain.Users;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.AggregatesModel.Categories;
using Core.Domain.Exceptions;
using Core.Application.Receipts.Common;
using Core.Application.Common;

namespace Core.Application.Rceipts.CreateReceipt;

public sealed class CreateReceiptCommandHandler : ICommandHandler<CreateReceiptCommand>
{
    private readonly IUserProvider _userProvider;
    private readonly IReceiptRepository _receiptRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CreateReceiptCommandHandler(IUserProvider userProvider, IReceiptRepository receiptRepository, ICategoryRepository categoryRepository)
    {
        _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
        _receiptRepository = receiptRepository ?? throw new ArgumentNullException(nameof(receiptRepository));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task Handle(CreateReceiptCommand command)
    {
        if (!command.Items.Any())
        {
            throw new DomainException("Receipt have to have positions");
        }

        var user = await _userProvider.GetAsync(command.UserId);
        var items = await CreateItems(user, command.Items);
        var receipt = user.CreateReceipt(command.ShopName, command.DateTime, items);
        await _receiptRepository.AddAsync(receipt);
    }

    private async Task<IEnumerable<ReceiptItem>> CreateItems(User user, IEnumerable<ReceiptItemDto> itemDtos)
    {
        var items = new List<ReceiptItem>();

        foreach (var itemDto in itemDtos)
        {
            var category = await _categoryRepository.GetAsync(user, new CategoryId(itemDto.CategoryId));
            var item = category.CreateReceiptItem(itemDto.Name, itemDto.Price, itemDto.Quantity);
            items.Add(item);
        }

        return items;
    }
}