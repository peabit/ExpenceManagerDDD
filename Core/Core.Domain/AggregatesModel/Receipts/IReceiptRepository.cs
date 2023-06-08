using Core.Domain.Common;
using Core.Domain.Users;

namespace Core.Domain.AggregatesModel.Receipts;

public interface IReceiptRepository : IRepository<Receipt>
{
    Task<Receipt> GetAsync(User user, ReceiptId id);
    Task AddAsync(Receipt receipt);
    void Delete(Receipt receipt);
}