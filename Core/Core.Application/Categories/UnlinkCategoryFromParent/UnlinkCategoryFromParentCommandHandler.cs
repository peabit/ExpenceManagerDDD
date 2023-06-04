using Core.Application.Categories.Common;
using Core.Application.Common;

namespace Core.Application.Categories.UnlinkCategoryFromParent;

public sealed class UnlinkCategoryFromParentCommandHandler : ICommandHandler<UnlinkCategoryFromParentCommand>
{
    private readonly CategoryChanger _categoryChanger;

    public UnlinkCategoryFromParentCommandHandler(CategoryChanger categoryChanger) 
        => _categoryChanger = categoryChanger ?? throw new ArgumentNullException(nameof(categoryChanger));

    public async Task HandleAsync(UnlinkCategoryFromParentCommand command)
        => await _categoryChanger.Change(command, c => c.UnlinkFromParentCategory());
}