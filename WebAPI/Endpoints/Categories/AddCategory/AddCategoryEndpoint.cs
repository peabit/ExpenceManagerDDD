using Core.Application.Categories.AddCategory;
using Core.Application.Common;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Endpoints.Categories.AddCategory;

namespace WebAPI.Endpoints.Categories.GetAllCategories;

[ApiExplorerSettings(GroupName = "Categories")]
[Route("api")]
[ApiController]
public class AddCategoryEndpoint : Controller
{
    private readonly ICommandHandler<AddCategoryCommand> _handler;

    public AddCategoryEndpoint(ICommandHandler<AddCategoryCommand> handler)
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpPost("{userId}/categories")]
    public async Task<IActionResult> HandleAsync(string userId, AddCategoryRequest request)
    {
        await _handler.HandleAsync(
            new AddCategoryCommand(userId, request.Name, request.ParentCategoryId)
        );

        return NoContent();
    }
}