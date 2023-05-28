using Core.Application.Categories.Common;
using Core.Application.Common;
using Core.Domain.AggregatesModel.Categories;
using Core.Domain.Users;

namespace Core.Application.Categories.LinkCategoryToParent;

public sealed class LinkCategoryToParentCommandHandler : ICommandHandler<LinkCategoryToParentCommand>
{
    private readonly CategoryChanger _categoryChanger;
    private readonly ICategoryRepository _categoryRepository;

    public LinkCategoryToParentCommandHandler(CategoryChanger categoryChanger, ICategoryRepository categoryRepository)
    {
        _categoryChanger = categoryChanger ?? throw new ArgumentNullException(nameof(categoryChanger));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task Handle(LinkCategoryToParentCommand command)
    {
        var parentCategory = await _categoryRepository.GetAsync(new User(command.UserId), new CategoryId(command.ParentCategoryId));
        await _categoryChanger.Change(command, c => c.LinkToParentCategory(parentCategory));
    }
}