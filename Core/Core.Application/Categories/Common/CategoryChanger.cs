using Core.Application.Receipts.Common;
using Core.Domain.AggregatesModel.Categories;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;

namespace Core.Application.Categories.Common;

public abstract class CategoryChanger
{
    private readonly ICategoryRepository _categoryRepository;

    protected CategoryChanger(IReceiptRepository categoryRepository)
        => _categoryRepository = categoryRepository;

    public async Task Change<TCommand>(TCommand command, Action<Receipt> action)
        where TCommand : ManipulateReceiptCommand
    {
        var receipt = await _categoryRepository.GetAsync(new User(command.UserId), new ReceiptId(command.ReceiptId));
        action(receipt);
        await _categoryRepository.UpdateAsync(receipt);
    }
}