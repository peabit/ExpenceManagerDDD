using Core.Application.Common;
using Core.Application.Receipts.ChangeReceiptDateTime;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Receipts.ChangeReceiptDateTime;

[ApiExplorerSettings(GroupName = "Receipts")]
[Route("api")]
[ApiController]
public sealed class ChangeReceiptDateTimeEndpoint : Controller
{
    private readonly ICommandHandler<ChangeReceiptDateTimeCommand> _handler;

    public ChangeReceiptDateTimeEndpoint(ICommandHandler<ChangeReceiptDateTimeCommand> handler) 
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpPut("{userId}/receipts/{receiptId}/dateTime")]
    public async Task<IActionResult> HandleAsync(string userId, string receiptId, ChangeReceiptDateTimeRequest request)
    {
        await _handler.HandleAsync(
            new ChangeReceiptDateTimeCommand(userId, receiptId, request.newDateTime)
        );

        return NoContent();
    }
}