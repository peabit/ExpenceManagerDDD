using Core.Application.Receipts.Common;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.AggregatesModel.Categories;
using Core.Application.Common;
using Core.Domain.Users;

namespace Core.Application.Receipts.AddItemToReceipt;

public class AddItemToReceiptCommandHandler : ICommandHandler<AddItemToReceiptCommand>
{
    private readonly ReceiptChanger _receiptChanger;
    private readonly ICategoryRepository _categoryRepository;

    public AddItemToReceiptCommandHandler(ReceiptChanger receiptChanger, ICategoryRepository categoryRepository)
    {
        _receiptChanger = receiptChanger;
        _categoryRepository = categoryRepository;
    }

    public async Task HandleAsync(AddItemToReceiptCommand command)
        => await _receiptChanger.Change(command, async (receipt) => await AddItemToReceipt(command, receipt));

    private async Task AddItemToReceipt(AddItemToReceiptCommand command, Receipt receipt)
    {
        var categoryId = new CategoryId(command.NewItem.CategoryId);
        var user = new User(command.UserId);

        var category = await _categoryRepository.GetAsync(user, categoryId);
        var item = category.CreateReceiptItem(command.NewItem.Name, command.NewItem.Price, command.NewItem.Quantity);
        receipt.AddItem(item);
    }
}