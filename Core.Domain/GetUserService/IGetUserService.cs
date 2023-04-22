using Core.Domain.AggregatesModel.UserAggregate;

namespace Core.Domain.GetUserService;

public interface IGetUserService
{
    Task<User> Get(UserId userId);
}