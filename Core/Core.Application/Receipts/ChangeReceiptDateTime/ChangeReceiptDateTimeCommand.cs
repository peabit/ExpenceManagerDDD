using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.ChangeReceiptDateTime;

public sealed record ChangeReceiptDateTimeCommand(
    string UserId, 
    string ReceiptId, 
    DateTime NewDateTime
) 
: ManipulateReceiptCommand(UserId, ReceiptId);