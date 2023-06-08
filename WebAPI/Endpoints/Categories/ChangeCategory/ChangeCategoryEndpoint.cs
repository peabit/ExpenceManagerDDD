using Core.Application.Categories.ChangeCategory;
using Core.Application.Common;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Endpoints.Categories.ChangeCategory;

namespace WebAPI.Endpoints.Categories.GetAllCategories;

[ApiExplorerSettings(GroupName = "Categories")]
[Route("api")]
[ApiController]
public class ChangeCategoryEndpoint : Controller
{
    private readonly ICommandHandler<ChangeCategoryCommand> _handler;

    public ChangeCategoryEndpoint(ICommandHandler<ChangeCategoryCommand> handler)
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpPut("{userId}/categories/{categoryId}")]
    public async Task<IActionResult> HandleAsync(string userId, string categoryId, ChangeCategoryRequest request)
    {
        await _handler.HandleAsync(
            new ChangeCategoryCommand(userId, categoryId, request.Name, request.ParentCategoryId)
        );
        
        return NoContent();
    }
}