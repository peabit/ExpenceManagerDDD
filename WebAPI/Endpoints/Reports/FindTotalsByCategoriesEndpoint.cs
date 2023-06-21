using Core.Application.Common;
using Core.Application.Reports.FindTotalsByCategories;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Reports;

[Route("api/reports")]
[ApiController]
public class FindTotalsByCategoriesEndpoint : Controller
{
    private readonly IQueryHandler<FindTotalsByCategoriesQuery, TotalsByCategoriesDto> _handler;

    public FindTotalsByCategoriesEndpoint(IQueryHandler<FindTotalsByCategoriesQuery, TotalsByCategoriesDto> handler) 
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpGet("{userId}/totals/{from:datetime}&{to:datetime}")]
    public async Task<IActionResult> Handle (string userId, DateTime from, DateTime to)
    {
        var totals = await _handler.HandleAsync(
            new FindTotalsByCategoriesQuery(userId, from, to, new string[] { "03fd2172-0ec1-4fda-b318-3294d3c25bdd", "b8ca8254-e953-47dc-b343-b09abca3d328" })
        );

        return Ok(totals);
    }
}