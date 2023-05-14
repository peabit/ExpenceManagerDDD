using Core.Domain.Common;

namespace Core.Domain.Users;

public interface IUserProvider
{
    Task<User> GetAsync(string userId);
}