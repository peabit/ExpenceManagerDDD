using Core.Application.Common;
using Core.Application.Receipts.Common;
using Core.Domain.AggregatesModel.Categories;
using Core.Domain.Users;

namespace Core.Application.Receipts.Items.ChangeReceiptItemCategory;

public class ChangeReceiptItemCategoryCommandHandler : ICommandHandler<ChangeReceiptItemCategoryCommand>
{
    private readonly ReceiptItemChanger _receiptItemChanger;
    private readonly ICategoryRepository _categoryRepository;

    public ChangeReceiptItemCategoryCommandHandler(ReceiptItemChanger receiptItemChanger, ICategoryRepository categoryRepository)
    {
        _receiptItemChanger = receiptItemChanger ?? throw new ArgumentNullException(nameof(receiptItemChanger));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task Handle(ChangeReceiptItemCategoryCommand command)
    {
        var newCategory = await _categoryRepository.GetAsync(new User(command.UserId), new CategoryId(command.NewCategoryId));
        await _receiptItemChanger.Change(command, item => item.ChangeCategoryTo(newCategory));
    }
}