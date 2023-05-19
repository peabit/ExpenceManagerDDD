using Core.Application.Rceipts.Common;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.AggregatesModel.Categories;

namespace Core.Application.Rceipts.AddItemToReceipt;

public class AddItemToReceiptCommandHandler
{
    private IReceiptRepository _receiptRepository;

    public AddItemToReceiptCommandHandler(IReceiptRepository receiptRepository) => 
        _receiptRepository = receiptRepository;

    public async Task Handle(AddItemToReceiptCommand command)
    {
        var recceipt = await _receiptRepository.GetForManipulateCommandAsync(command);

        var newItem = new ReceiptItem(
            new CategoryId(command.NewItem.CategoryId), command.NewItem.Name, command.NewItem.Price, command.NewItem.Quantity
        );
        
        recceipt.AddItem(newItem);
        await _receiptRepository.UpdateAsync(recceipt);
    }
}