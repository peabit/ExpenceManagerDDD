using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.ReceiptAggregate;

public interface IReceiptRepository : IRepository<Receipt>
{
    Task<Receipt> GetAsync(ReceiptId id);
    Task AddAsync(Receipt receipt);
    Task UpdateAsync(Receipt receipt);
    Task DeleteAsync(ReceiptId id);
}