using Core.Application.Common;
using Core.Domain.AggregatesModel.Categories;
using Core.Domain.Users;

namespace Core.Application.Categories.ChangeCategory;

public sealed class ChangeCategoryCommandHandler : ICommandHandler<ChangeCategoryCommand>
{
    private readonly ICategoryProvider _categoryProvider;
    private readonly IUserProvider _userProvider;

    public ChangeCategoryCommandHandler(ICategoryProvider categoryRepository, IUserProvider userProvider)
    {
        _categoryProvider = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
    }

    public async Task HandleAsync(ChangeCategoryCommand command)
    {
        var category = await GetCategoryAsync(command.UserId, command.CategoryId);

        if (command.Name is not null)
        {
            category.ChangeNameTo(command.Name);
        }

        if (command.ParentCategoryId is not null)
        {
            await ChangeParentCategory(category, command.UserId, command.ParentCategoryId);
        }
    }

    private async Task ChangeParentCategory(Category category, string userId, string parentCategoryId)
    {
        if (parentCategoryId == String.Empty)
        {
            category.UnlinkFromParentCategory();
            return;
        }

        var parentCategory = await GetCategoryAsync(userId,parentCategoryId);

        category.LinkToParentCategory(parentCategory);
    }

    private async Task<Category> GetCategoryAsync(string userId, string categoryId)
    {
        var user = await _userProvider.GetAsync(userId);

        var category = await _categoryProvider.GetAsync(user, new CategoryId(categoryId));

        return category;
    }
}