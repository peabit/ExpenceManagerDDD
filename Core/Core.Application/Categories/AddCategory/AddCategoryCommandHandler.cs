using Core.Application.Common;
using Core.Domain.AggregatesModel.Categories;
using Core.Domain.Users;

namespace Core.Application.Categories.AddCategory;

public sealed class AddCategoryCommandHandler : ICommandHandler<AddCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserProvider _userProvider;

    public AddCategoryCommandHandler(ICategoryRepository categoryRepository, IUserProvider userProvider)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
    }

    public async Task HandleAsync(AddCategoryCommand command)
    {
        var user = await _userProvider.GetAsync(command.UserId);

        Category parentCategory = null!;

        if (command.ParentCategoryId is not null)
        {
            parentCategory = await _categoryRepository.GetAsync(user, new CategoryId(command.ParentCategoryId));
        }
        
        var category = user.CreateCategory(command.Name, parentCategory);

        await _categoryRepository.AddAsync(category);
    }
}