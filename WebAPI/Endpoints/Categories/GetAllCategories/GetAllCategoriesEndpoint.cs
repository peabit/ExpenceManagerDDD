using Core.Application.Categories.Common;
using Core.Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Categories.GetAllCategories;

[ApiExplorerSettings(GroupName = "Categories")]
[Route("api")]
[ApiController]
public class GetAllCategoriesEndpoint : Controller
{
    private readonly IQueryHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>> _handler;

    public GetAllCategoriesEndpoint(IQueryHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>> handler)
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpGet("{userId}/categories")]
    public async Task<IActionResult> HandleAsync(string userId)
    {
        var categories = await _handler.HandleAsync(new GetAllCategoriesQuery(userId));
        return Ok(categories);
    }
}