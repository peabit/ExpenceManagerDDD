using Core.Domain.AggregatesModel.Categories;
using Core.Domain.Exceptions;
using Core.Domain.Users;
using Core.Infrastructure.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Domain.Categories;

public class CategoryRepository : ICategoryRepository
{
    private readonly CoreDbContext _dbContext;

    public CategoryRepository(CoreDbContext dbContext)
        => _dbContext = dbContext;
    
    public async Task AddAsync(Category category)
        => await _dbContext.Categories.AddAsync(category);

    public void Delete(Category category)
        => _dbContext.Categories.Remove(category); 

    public async Task<IEnumerable<Category>> GetAsync(User user)
    {
        var categories = await _dbContext.Categories.Where(c => c.User == user).ToArrayAsync();

        if (!categories.Any())
        {
            throw new NotFoundException($"User with id {user} does not have categories");
        }

        return categories;
    }

    public async Task<Category> GetAsync(User user, CategoryId id)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.User == user & c.Id == id);

        if (category is null)
        {
            throw new NotFoundException($"User with id {user} does not have category with id {id}");
        }

        return category;
    }
}