using Core.Application.Common;
using Core.Application.Receipts.Common;

namespace Core.Application.Receipts.FindReceiptsByPeriod;

public sealed class FindReceiptsByPeriodQueryHandler 
    : IQueryHandler<FindReceiptsByPeriodQuery, IEnumerable<ReceiptHeaderDto>>
{
    private readonly ISqlQueryExecutor _queryExecutor;

    public FindReceiptsByPeriodQueryHandler(ISqlQueryExecutor queryExecutor) 
        => _queryExecutor = queryExecutor ?? throw new ArgumentNullException(nameof(queryExecutor));

    public async Task<IEnumerable<ReceiptHeaderDto>> Handle(FindReceiptsByPeriodQuery query)
    {
        var sqlQuery = """
            WITH 
                Total AS (
        	        SELECT
        		        Receipts.Id AS ReceiptId,
        		        SUM( ReceiptItems.Quantity * ReceiptItems.Price ) AS Value
        	        FROM Receipts
        	        JOIN ReceiptItems
        	          ON Receipts.Id = ReceiptItems.ReceiptId
                    WHERE Receipts.DateTime BETWEEN @From AND @To 
                      AND Receipts.UserId = @UserId
        	        GROUP BY Receipts.Id		
                )
            SELECT
                Receipts.Id,
            	Receipts.ShopName,
            	Receipts.DateTime,
            	Total.Value AS Total
            FROM Receipts
            JOIN Total
              ON Receipts.Id = Total.ReceiptId
        """;

        return await _queryExecutor.Query<ReceiptHeaderDto>(sqlQuery, query);
    }
}