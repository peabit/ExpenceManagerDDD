using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Users;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByIdAsync(UserId userId);
    Task<bool> ContainsAsync(UserId userId);
}