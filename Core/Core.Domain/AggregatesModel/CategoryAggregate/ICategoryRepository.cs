using Core.Domain.Common;

namespace Core.Domain.AggregatesModel.CategoryAggregate;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category> GetAsync(CategoryId id);
    Task<IEnumerable<Category>> GetAllAsync(CategoryId id);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(CategoryId category);
}