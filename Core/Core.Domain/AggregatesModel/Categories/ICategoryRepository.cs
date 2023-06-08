using Core.Domain.Users;
using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Categories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<IEnumerable<Category>> GetAsync(User user);
    Task<Category> GetAsync(User user, CategoryId id);
    Task AddAsync(Category category);
    void Delete(Category category);
}