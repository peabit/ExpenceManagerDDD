using Core.Application.Common;
using Core.Application.Receipts.AddItemToReceipt;
using Core.Application.Receipts.Common;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Receipts.AddItemToReceipt;

[ApiExplorerSettings(GroupName = "Receipts")]
[Route("api")]
[ApiController]
public sealed class AddItemToReceiptEndpoint : Controller
{
    private readonly ICommandHandler<AddItemToReceiptCommand> _handler;

    public AddItemToReceiptEndpoint(ICommandHandler<AddItemToReceiptCommand> handler) 
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpPost("userId/receipts/{receiptId}/items")]
    public async Task<IActionResult> HandleAsync(string userId, string receiptId, NewReceiptItemDto newReceiptItemDto)
    {
        await _handler.HandleAsync(
            new AddItemToReceiptCommand(userId, receiptId, newReceiptItemDto)
        );

        return Created(uri: String.Empty, value: null);
    }
}