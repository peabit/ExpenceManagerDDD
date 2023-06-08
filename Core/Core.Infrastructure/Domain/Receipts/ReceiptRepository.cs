using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Exceptions;
using Core.Domain.Users;
using Core.Infrastructure.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Domain.Receipts;

public class ReceiptRepository : IReceiptRepository
{
    private readonly CoreDbContext _dbContext;

    public ReceiptRepository(CoreDbContext dbContext)
        => _dbContext = dbContext;

    public async Task AddAsync(Receipt receipt)
        => await _dbContext.Receipts.AddAsync(receipt);

    public void Delete(Receipt receipt)
        => _dbContext.Receipts.Remove(receipt);

    public async Task<Receipt> GetAsync(User user, ReceiptId id)
    {
        var receipt = await _dbContext.Receipts.SingleAsync(r => r.User == user && r.Id == id);

        if (receipt is null)
        {
            throw new NotFoundException($"Receipt with id {id} not found");
        }

        return receipt;
    }
}