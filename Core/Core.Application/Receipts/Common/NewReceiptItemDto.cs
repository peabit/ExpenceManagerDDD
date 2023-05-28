namespace Core.Application.Receipts.Common;

public sealed record NewReceiptItemDto(
    string CategoryId,
    string Name,
    decimal Price,
    int Quantity
);