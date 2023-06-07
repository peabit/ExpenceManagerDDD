using Core.Application.Common;
using Core.Application.Receipts.DeleteReceiptItem;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Receipts.DeleteReceiptItem;

[ApiExplorerSettings(GroupName = "Receipts")]
[Route("api")]
[ApiController]
public sealed class DeleteReceiptItem : Controller
{
    private readonly ICommandHandler<DeleteReceiptItemCommand> _handler;

    public DeleteReceiptItem(ICommandHandler<DeleteReceiptItemCommand> handler) 
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpDelete("api/{userId}/receipts/{receiptId}/items/{itemId}")]
    public async Task<IActionResult> HandleAsync(string userId, string receiptId, string itemId)
    {
        await _handler.HandleAsync(
            new DeleteReceiptItemCommand(userId, receiptId, itemId)
        );

        return NoContent();
    }
}