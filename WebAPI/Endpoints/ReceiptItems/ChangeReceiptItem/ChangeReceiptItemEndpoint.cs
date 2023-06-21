using Core.Application.Common;
using Core.Application.Receipts.ChangeReceiptItem;
using Microsoft.AspNetCore.Mvc;
using SimpleInjector;

namespace WebAPI.Endpoints.ReceiptItems.ChangeReceiptItem;

[ApiExplorerSettings(GroupName = "ReceiptItems")]
[Route("api")]
[ApiController]
public sealed class ChangeReceiptItemEndpoint : Controller
{
    private readonly ICommandHandler<ChangeReceiptItemCommand> _handler;

    public ChangeReceiptItemEndpoint(ICommandHandler<ChangeReceiptItemCommand> handler, Container container) 
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpPut("userId/receipts/{receiptId}/items/{itemId}")]
    public async Task<IActionResult> HandleAsync(string userId, string receiptId, string itemId, ChangeReceiptItemRequest request)
    {
        await _handler.HandleAsync(
            new ChangeReceiptItemCommand(
                userId, 
                receiptId, 
                itemId, 
                request.CategoryId, 
                request.Name, 
                request.Price, 
                request.Quantity)
        );

        return NoContent();
    }
}