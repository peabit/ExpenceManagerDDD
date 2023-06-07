using Core.Application.Common;
using Core.Application.Receipts.ChangeReceiptShopName;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Receipts.ChangeReceiptShopName;

[ApiExplorerSettings(GroupName = "Receipts")]
[Route("api")]
[ApiController]
public sealed class ChangeReceiptShopNameEndpoint : Controller
{
    private readonly ICommandHandler<ChangeReceiptShopNameCommand> _handler;

    public ChangeReceiptShopNameEndpoint(ICommandHandler<ChangeReceiptShopNameCommand> handler) 
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpPut("{userId}/receipts/{receiptId}/shopName")]
    public async Task<IActionResult> HandleAsync(string userId, string receiptId, ChangeReceiptShopNameRequest request)
    {
        await _handler.HandleAsync(
            new ChangeReceiptShopNameCommand(userId, receiptId, request.newShopName)
        );

        return NoContent();
    }
}