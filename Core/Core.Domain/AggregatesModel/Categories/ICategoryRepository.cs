using Core.Domain.Users;
using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Categories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category> GetAsync(CategoryId id);
    Task<Category> GetAsync(User user, CategoryId id);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(CategoryId categoryId);
}