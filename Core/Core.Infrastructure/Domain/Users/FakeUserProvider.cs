using Core.Domain.Users;

namespace Core.Infrastructure.Domain.Users;

public class FakeUserProvider : IUserProvider
{
    public Task<User> GetAsync(string userId)
    {
        return Task.FromResult(new User("555"));
    }
}