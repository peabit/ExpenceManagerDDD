using Core.Application.Common;
using Core.Application.Receipts.AddReceipt;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Receipts.AddReceipt;

[ApiExplorerSettings(GroupName = "Receipts")]
[Route("api/{userId}/receipts")]
[ApiController]
public sealed class AddReceiptEndpoint : Controller
{
    private readonly ICommandHandler<AddReceiptCommand> _handler;

    public AddReceiptEndpoint(ICommandHandler<AddReceiptCommand> handler)
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpPost]
    public async Task<IActionResult> HandleAsync(string userId, AddReceiptRequest request)
    {
        await _handler.HandleAsync(
            new AddReceiptCommand(userId, request.ShopName, request.DateTime, request.Items)
        );

        return Created(uri: String.Empty, value: null);
    }
}