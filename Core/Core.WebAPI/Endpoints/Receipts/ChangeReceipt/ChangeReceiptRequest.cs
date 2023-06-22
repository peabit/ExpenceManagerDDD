namespace WebAPI.Endpoints.Receipts.ChangeReceipt;

public sealed record ChangeReceiptRequest(
    string? ShopName, 
    DateTime? DateTime
);
