using Core.Application.Categories.Common;
using Core.Application.Common;

namespace Core.Application.Categories.RenameCategory;

public sealed class RenameCategoryCommandHandler : ICommandHandler<RenameCategoryCommand>
{
    private readonly CategoryChanger _categoryChanger;

    public RenameCategoryCommandHandler(CategoryChanger categoryChanger) 
        => _categoryChanger = categoryChanger ?? throw new ArgumentNullException(nameof(categoryChanger));

    public async Task HandleAsync(RenameCategoryCommand command)
        => await _categoryChanger.Change(command, c => c.ChangeNameTo(command.NewName));
}