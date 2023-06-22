using Core.Application.Common;
using Core.Application.Receipts.ChangeReceipt;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Receipts.ChangeReceipt;

[ApiExplorerSettings(GroupName = "Receipts")]
[Route("api/{userId}/receipts/{receiptId}")]
[ApiController]
public sealed class ChangeReceiptEndpoint : Controller
{
    private readonly ICommandHandler<ChangeReceiptCommand> _handler;

    public ChangeReceiptEndpoint(ICommandHandler<ChangeReceiptCommand> handler) 
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpPut]
    public async Task<IActionResult> HandleAsync(string userId, string receiptId, ChangeReceiptRequest request)
    {
        await _handler.HandleAsync(
            new ChangeReceiptCommand(userId, receiptId, request.ShopName, request.DateTime)
        );

        return NoContent();
    }
}