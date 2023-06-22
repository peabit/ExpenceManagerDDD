using Core.Application.Common;
using Core.Application.Receipts.Common;
using Core.Application.Receipts.FindReceiptsByPeriod;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Receipts.FindReceiptsByPeriod;

[ApiExplorerSettings(GroupName = "Receipts")]
[Route("api/{userId}/receipts/{from:datetime}&{to:datetime}")]
[ApiController]
public sealed class FindReceiptsByPeriod : Controller
{
    private readonly IQueryHandler<FindReceiptsByPeriodQuery, IEnumerable<ReceiptHeaderDto>> _handler;

    public FindReceiptsByPeriod(IQueryHandler<FindReceiptsByPeriodQuery, IEnumerable<ReceiptHeaderDto>> handler) 
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpGet]
    public async Task<IActionResult> HandleAsync(string userId, DateTime from, DateTime to)
    {
        var receipts = await _handler.HandleAsync(
            new FindReceiptsByPeriodQuery(userId, from, to)
        );

        if (!receipts.Any())
        {
            return NotFound();
        }

        return Ok(receipts);
    }
}