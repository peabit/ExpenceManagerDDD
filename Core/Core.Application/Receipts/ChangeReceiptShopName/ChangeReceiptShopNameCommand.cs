﻿using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.ChangeReceiptShopName;

public sealed record ChangeReceiptShopNameCommand(
    string UserId,
    string ReceiptId,
    string ItemId,
    string NewShopName
) 
: ManipulateReceiptCommand(UserId, ReceiptId);