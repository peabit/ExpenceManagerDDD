using Core.Domain.Users;

namespace Core.Domain.AggregatesModel.Categories;

public interface ICategoryProvider
{
    Task<Category> GetAsync(User user, CategoryId id);
}
