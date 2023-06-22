using Core.Application.Common;
using Core.Application.Reports.FindTotalsByCategories;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Reports;

[ApiExplorerSettings(GroupName = "Totals by categories report")]
[Route("api/reports/{userId}/totals/{from:datetime}&{to:datetime}")]
[ApiController]
public class FindTotalsByCategoriesEndpoint : Controller
{
    private readonly IQueryHandler<FindTotalsByCategoriesQuery, TotalsByCategoriesDto> _handler;

    public FindTotalsByCategoriesEndpoint(IQueryHandler<FindTotalsByCategoriesQuery, TotalsByCategoriesDto> handler) 
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpGet]
    public async Task<IActionResult> Handle (string userId, DateTime from, DateTime to, [FromQuery]string[] categoryIds)
    {
        var totals = await _handler.HandleAsync(
            new FindTotalsByCategoriesQuery(userId, from, to, categoryIds)
        );

        return Ok(totals);
    }
}