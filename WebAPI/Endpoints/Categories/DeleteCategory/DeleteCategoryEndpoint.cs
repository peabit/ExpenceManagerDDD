using Core.Application.Categories.DeleteCategory;
using Core.Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Categories.DeleteCategory;

[ApiExplorerSettings(GroupName = "Categories")]
[Route("api")]
[ApiController]
public class DeleteCategoryEndpoint : Controller
{
    private readonly ICommandHandler<DeleteCategoryCommand> _handler;

    public DeleteCategoryEndpoint(ICommandHandler<DeleteCategoryCommand> handler)
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpDelete("{userId}/categories/{categoryId}")]
    public async Task<IActionResult> HandleAsync(string userId, string categoryId)
    {
        await _handler.HandleAsync(new DeleteCategoryCommand(userId, categoryId));
        return NoContent();
    }
}