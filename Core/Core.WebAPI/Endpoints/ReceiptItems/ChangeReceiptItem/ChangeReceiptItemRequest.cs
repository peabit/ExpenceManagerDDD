namespace WebAPI.Endpoints.ReceiptItems.ChangeReceiptItem;

public sealed record ChangeReceiptItemRequest(
    string? CategoryId,
    string? Name,
    decimal? Price,
    int? Quantity
);