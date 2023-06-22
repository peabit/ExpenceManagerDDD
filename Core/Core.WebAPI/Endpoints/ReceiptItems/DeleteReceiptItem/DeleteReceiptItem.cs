using Core.Application.Common;
using Core.Application.Receipts.DeleteReceiptItem;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.ReceiptItems.DeleteReceiptItem;

[ApiExplorerSettings(GroupName = "Receipt items")]
[Route("api/{userId}/receipts/{receiptId}/items/{itemId}")]
[ApiController]
public sealed class DeleteReceiptItem : Controller
{
    private readonly ICommandHandler<DeleteReceiptItemCommand> _handler;

    public DeleteReceiptItem(ICommandHandler<DeleteReceiptItemCommand> handler)
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpDelete]
    public async Task<IActionResult> HandleAsync(string userId, string receiptId, string itemId)
    {
        await _handler.HandleAsync(
            new DeleteReceiptItemCommand(userId, receiptId, itemId)
        );

        return NoContent();
    }
}