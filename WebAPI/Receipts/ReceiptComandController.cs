using Core.Application.Common;
using Core.Application.Receipts.AddItemToReceipt;
using Core.Application.Receipts.AddReceipt;
using Core.Application.Receipts.ChangeReceiptDateTime;
using Core.Application.Receipts.ChangeReceiptShopName;
using Core.Application.Receipts.DeleteReceipt;
using Core.Application.Receipts.DeleteReceiptItem;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common;

namespace WebAPI.Receipts;

[ApiExplorerSettings(GroupName = "Receipts")]
[Route("api/receipts")]
[ApiController]
public class ReceiptComandController : ControllerBase
{
    private readonly ICommandHandler<AddReceiptCommand> _addHandler;
    private readonly ICommandHandler<ChangeReceiptDateTimeCommand> _changeDateTimeHandler;
    private readonly ICommandHandler<ChangeReceiptShopNameCommand> _changeShopNameHandler;
    private readonly ICommandHandler<DeleteReceiptCommand> _deleteHandler;
    private readonly ICommandHandler<AddItemToReceiptCommand> _addItemHandler;
    private readonly ICommandHandler<DeleteReceiptItemCommand> _deleteItemHandler;

    private const string UserId = "555";

    public ReceiptComandController(
        ICommandHandler<AddReceiptCommand> addHandler,
        ICommandHandler<ChangeReceiptDateTimeCommand> changeDateTimeHandler,
        ICommandHandler<ChangeReceiptShopNameCommand> changeShopNameHandler,
        ICommandHandler<DeleteReceiptCommand> deleteHandler,
        ICommandHandler<AddItemToReceiptCommand> addItemHandler,
        ICommandHandler<DeleteReceiptItemCommand> deleteItemHandler
    )
    {
        _addHandler = addHandler ?? throw new ArgumentNullException(nameof(addHandler));
        _changeDateTimeHandler = changeDateTimeHandler ?? throw new ArgumentNullException(nameof(changeDateTimeHandler));
        _changeShopNameHandler = changeShopNameHandler ?? throw new ArgumentNullException(nameof(changeShopNameHandler));
        _deleteHandler = deleteHandler ?? throw new ArgumentNullException(nameof(deleteHandler));
        _addItemHandler = addItemHandler ?? throw new ArgumentNullException(nameof(addItemHandler));
        _deleteItemHandler = deleteItemHandler ?? throw new ArgumentNullException(nameof(deleteItemHandler));
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(AddReceiptRequest request)
    {
        var command = new AddReceiptCommand(UserId, request.ShopName, request.DateTime, request.Items);
        await _addHandler.HandleAsync(command);

        return this.Created();
    }
}