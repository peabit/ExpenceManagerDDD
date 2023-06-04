using Core.Application.Common;
using Core.Application.Receipts.Common;
using Core.Application.Receipts.FindReceiptsByPeriod;
using Core.Application.Receipts.GetReceipt;
using Core.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiExplorerSettings(GroupName = "Receipts")]
[Route("api/receipts")]
[ApiController]
public class ReceiptQueryController : ControllerBase
{
    private readonly IQueryHandler<GetReceiptQuery, ReceiptDto> _getReceiptHandler;
    private readonly IQueryHandler<FindReceiptsByPeriodQuery, IEnumerable<ReceiptHeaderDto>> _findReceiptsByPeriod;

    private const string UserId = "555";

    public ReceiptQueryController(
        IQueryHandler<GetReceiptQuery, ReceiptDto> getReceiptHandler,
        IQueryHandler<FindReceiptsByPeriodQuery, IEnumerable<ReceiptHeaderDto>> findReceiptsByPeriod
    )
    {
        _getReceiptHandler = getReceiptHandler;
        _findReceiptsByPeriod = findReceiptsByPeriod;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingleByIdAsync(string id)
    {
        var query = new GetReceiptQuery(UserId, id);
        var receipt = await _getReceiptHandler.HandleAsync(query);
        
        return Ok(receipt);
    }

    [HttpGet("{from:datetime}&{to:datetime}")]
    public async Task<IActionResult> FindByPeriodAsync(DateTime from, DateTime to)
    {
        var query = new FindReceiptsByPeriodQuery(UserId, from, to);    
        var receipts = await _findReceiptsByPeriod.HandleAsync(query);

        if (receipts.Any())
        {
            return Ok(receipts);
        }

        return NotFound();
    }
}