using Core.Application.Common;
using Core.Application.Receipts.GetReceipt;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("receipts")]
public class ReceiptQueryController : Controller
{
    private readonly IQueryHandler<GetReceiptQuery, ReceiptDto> _getReceiptHandler;
    
    private const string UserId = "555";

    public ReceiptQueryController(IQueryHandler<GetReceiptQuery, ReceiptDto> getReceiptHandler)
    {
        _getReceiptHandler = getReceiptHandler;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var query = new GetReceiptQuery(UserId, id);
        var receipt = await _getReceiptHandler.Handle(query);
        
        return Ok(receipt);
    }
}