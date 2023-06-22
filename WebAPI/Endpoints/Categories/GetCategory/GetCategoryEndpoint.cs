using Core.Application.Categories.Common;
using Core.Application.Categories.GetCategory;
using Core.Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Categories.GetAllCategories;

[ApiExplorerSettings(GroupName = "Categories")]
[Route("api/{userId}/categories/{categoryId}")]
[ApiController]
public class GetCategoryEndpoint : Controller
{
    private readonly IQueryHandler<GetCategoryQuery, CategoryDto> _handler;

    public GetCategoryEndpoint(IQueryHandler<GetCategoryQuery, CategoryDto> handler)
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpGet]
    public async Task<IActionResult> HandleAsync(string userId, string categoryId)
    {
        var category = await _handler.HandleAsync(new GetCategoryQuery(userId, categoryId));
        return Ok(category);
    }
}