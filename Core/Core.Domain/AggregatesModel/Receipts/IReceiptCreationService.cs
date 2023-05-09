using Core.Domain.AggregatesModel.Users;

namespace Core.Domain.AggregatesModel.Receipts;

public interface IReceiptCreationService
{
    Task<Receipt> CreateReceiptAsync(UserId userId, string shopName, DateTime dateTime, IEnumerable<ReceiptItem> items);
}