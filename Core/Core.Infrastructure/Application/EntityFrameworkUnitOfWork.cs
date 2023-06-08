using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Application;

public class EntityFrameworkUnitOfWork : IUnitOfWork
{
    private readonly DbContext _dbContext;

    public EntityFrameworkUnitOfWork(DbContext dbContext)
        => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task CommitAsync()
        => await _dbContext.SaveChangesAsync();
}