using Core.Application.Common;
using Core.Application.Receipts.GetReceipt;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Receipts.GetReceipt;

[ApiExplorerSettings(GroupName = "Receipts")]
[Route("api")]
[ApiController]
public sealed class GetReceiptEndpoint : Controller
{
    private readonly IQueryHandler<GetReceiptQuery, ReceiptDto> _handler;

    public GetReceiptEndpoint(IQueryHandler<GetReceiptQuery, ReceiptDto> handler) 
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpGet("{userId}/receipts{receiptId}")]
    public async Task<IActionResult> HandleAsync(string userId, string receiptId)
    {
        var receipt = await _handler.HandleAsync(new GetReceiptQuery(userId, receiptId));
        return Ok(receipt);
    }
}