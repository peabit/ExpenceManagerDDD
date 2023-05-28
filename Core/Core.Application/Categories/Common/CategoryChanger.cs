using Core.Domain.AggregatesModel.Categories;
using Core.Domain.Users;

namespace Core.Application.Categories.Common;

public class CategoryChanger
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryChanger(ICategoryRepository categoryRepository)
        => _categoryRepository = categoryRepository;

    public async Task Change<TCommand>(TCommand command, Action<Category> action)
        where TCommand : ManipulateCategoryCommand
    {
        var category = await _categoryRepository.GetAsync(new User(command.UserId), new CategoryId(command.CategoryId));
        action(category);
        await _categoryRepository.UpdateAsync(category);
    }
}