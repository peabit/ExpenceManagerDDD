﻿using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.Items.ChangeReceiptItemPrice;

public sealed record ChangeReceiptItemPriceCommand(
    string UserId,
    string ReceiptId,
    string ItemId,
    decimal NewPrice
)
: ManipulateReceiptItemCommand(UserId, ReceiptId, ItemId);