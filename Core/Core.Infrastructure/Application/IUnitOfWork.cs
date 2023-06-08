namespace Core.Infrastructure.Application;

public interface IUnitOfWork
{
    Task CommitAsync();
}