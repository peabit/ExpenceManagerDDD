using Core.Domain.AggregatesModel.Categories;
using Core.Domain.Users;

namespace Core.Infrastructure.Domain.Users;

public class FakeUserProvider : IUserProvider
{
    public FakeUserProvider(ICategoryProvider categoryProvider)
    {
            
    }

    public Task<User> GetAsync(string userId)
    {
        return Task.FromResult(new User(userId));
    }
}