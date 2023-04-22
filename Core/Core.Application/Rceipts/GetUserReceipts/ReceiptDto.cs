namespace Core.Application.Rceipts.GetUserReceipts;

public record ReceiptDto(
    Guid Id,
    string ShopName,
    DateTime DateTime,
    decimal Total
);