using Core.Domain.Users;
using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Categories;

public interface ICategoryRepository : IRepository<Category>, ICategoryProvider
{
    Task<IEnumerable<Category>> GetAsync(User user);
    Task AddAsync(Category category);
    void Delete(Category category);
}