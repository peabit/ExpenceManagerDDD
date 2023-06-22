using Core.Application.Common;
using Core.Application.Receipts.DeleteReceipt;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Receipts.DeleteReceipt;

[ApiExplorerSettings(GroupName = "Receipts")]
[Route("api/{userId}/receipts/{receiptId}")]
[ApiController]
public sealed class DeleteReceiptEndpoint : Controller
{
    private readonly ICommandHandler<DeleteReceiptCommand> _handler;

    public DeleteReceiptEndpoint(ICommandHandler<DeleteReceiptCommand> handler) 
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpDelete]
    public async Task<IActionResult> HandleAsync(string userId, string receiptId)
    {
        await _handler.HandleAsync(new DeleteReceiptCommand(userId, receiptId));
        return NoContent();
    }
}