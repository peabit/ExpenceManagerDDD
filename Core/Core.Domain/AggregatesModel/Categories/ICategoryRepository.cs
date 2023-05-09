using Core.Domain.AggregatesModel.Users;
using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.Categories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category> GetByIdAsync(CategoryId id);
    Task<IEnumerable<Category>> GetAllForUserAsync(UserId userId);
    Task<bool> ContainsAsync(UserId userId, CategoryId categoryId);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(CategoryId categoryId);
}