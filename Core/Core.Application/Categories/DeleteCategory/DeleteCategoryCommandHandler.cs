using Core.Application.Common;
using Core.Domain.AggregatesModel.Categories;
using Core.Domain.Users;

namespace Core.Application.Categories.DeleteCategory;

public sealed class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserProvider _userProvider;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUserProvider userProvider)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
    }

    public async Task HandleAsync(DeleteCategoryCommand command)
    {
        var user = await _userProvider.GetAsync(command.UserId);
        var category = await _categoryRepository.GetAsync(user, new CategoryId(command.CategoryId));
        _categoryRepository.Delete(category);
    }
}