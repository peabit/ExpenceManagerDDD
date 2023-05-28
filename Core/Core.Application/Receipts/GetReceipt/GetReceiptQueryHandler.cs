﻿using Core.Application.Common;
using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.GetReceipt;

public sealed class GetReceiptQueryHandler
    : IQueryHandler<GetReceiptQuery, ReceiptDto>
{
    private readonly ISqlQueryExecutor _queryExecutor;

    public GetReceiptQueryHandler(ISqlQueryExecutor queryExecutor) 
        => _queryExecutor = queryExecutor ?? throw new ArgumentNullException(nameof(queryExecutor));

    public async Task<ReceiptDto> Query(GetReceiptQuery query)
    {
        var headerDraft = await ReadHeaderDarft(query);
        var items = await ReadItems(query);
        var header = headerDraft with { Total = items.Sum(i => i.Coast) };
        
        return new ReceiptDto(header, items);
    }

    private async Task<ReceiptHeaderDto> ReadHeaderDarft(GetReceiptQuery query)
    {
        var sqlQuery = """
                SELECT Id, ShopName, DateTime 
                FROM Receipts 
                WHERE 
                    Id = @ReceiptId AND
                    UserId = @UserId
            """;

        return await _queryExecutor.QuerySingle<ReceiptHeaderDto>(sqlQuery, parameters: query);
    }

    private async Task<IEnumerable<ReceiptItemDto>> ReadItems(GetReceiptQuery query)
    {
        var sqlQuery = """
                SELECT 
                    ReceiptItems.Id,
                    ReceiptItems.Name,
                    ReceiptItems.Price,
                    ReceiptItems.Quantity,
                    ReceiptItems.Price * ReceiptItems.Quantity AS Coast,
                    Categories.Name AS Category
                
                FROM ReceiptItems
                
                JOIN Receipts
                    ON Receipts.Id = ReceiptItems.ReceiptId
                
                JOIN Categories
                    ON Categories.Id = ReceiptItems.CategoryId

                WHERE 
                    Receipts.Id = @ReceiptId AND
                    Receipts.UserId = @UserId		
            """;

        return await _queryExecutor.Query<ReceiptItemDto>(sqlQuery, parameters: query);
    }
}