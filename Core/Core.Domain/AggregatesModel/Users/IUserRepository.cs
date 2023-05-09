namespace Core.Domain.AggregatesModel.Users;

public interface IUserRepository
{
    Task<User> Get(UserId userId);
    Task<bool> Contains(UserId userId);
}