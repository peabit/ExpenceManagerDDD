using Core.Application.Receipts.Common;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.AggregatesModel.Categories;
using Core.Application.Common;
using Core.Domain.Users;

namespace Core.Application.Receipts.AddItemToReceipt;

public class AddItemToReceiptCommandHandler : ICommandHandler<AddItemToReceiptCommand>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserProvider _userProvider;

    public AddItemToReceiptCommandHandler(IReceiptRepository receiptRepository, ICategoryRepository categoryRepository, IUserProvider userProvider)
    {
        _receiptRepository = receiptRepository ?? throw new ArgumentNullException(nameof(receiptRepository));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _userProvider = userProvider ?? throw new ArgumentNullException( nameof(userProvider));
    }

    public async Task HandleAsync(AddItemToReceiptCommand command)
    {
        var user = await _userProvider.GetAsync(command.UserId);

        var receipt = await _receiptRepository.GetAsync(user, new ReceiptId(command.ReceiptId));
        
        var item = await CreateItem(command, user);
        
        receipt.AddItem(item);
    }

    private async Task<ReceiptItem> CreateItem(AddItemToReceiptCommand command, User user)
    {
        var category = await _categoryRepository.GetAsync(user, new CategoryId(command.NewItem.CategoryId));        
        
        var item = category.CreateReceiptItem(command.NewItem.Name, command.NewItem.Price, command.NewItem.Quantity);
        
        return item;
    }
}