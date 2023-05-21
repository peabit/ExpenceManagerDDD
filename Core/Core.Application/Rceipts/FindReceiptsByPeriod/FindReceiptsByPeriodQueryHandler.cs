using Core.Application.Common;

namespace Core.Application.Rceipts.FindReceiptsByPeriod;

public sealed class FindReceiptsByPeriodQueryHandler 
    : IQueryHandler<FindReceiptsByPeriodQuery, IEnumerable<ReceiptDto>>
{
    private readonly ISqlQueryExecutor _queryExecutor;

    public FindReceiptsByPeriodQueryHandler(ISqlQueryExecutor queryExecutor) 
        => _queryExecutor = queryExecutor ?? throw new ArgumentNullException(nameof(queryExecutor));

    public Task Handle(FindReceiptsByPeriodQuery command)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ReceiptDto>> Query(FindReceiptsByPeriodQuery query)
    {
        var paramters = new
        {
            From = query.From,
            To = query.To
        };

        var sqlQuery = """
            WITH 
                Coasts AS (
        	        SELECT
        		        Receipts.Id AS ReceiptId,
        		        SUM( ReceiptItems.Quantity * ReceiptItems.Price ) AS Value
        	        FROM Receipts
        	        JOIN ReceiptItems
        	          ON Receipts.Id = ReceiptItems.ReceiptId
                    WHERE Receipts.DateTime BETWEEN @From AND @To 
        	        GROUP BY 
        	        	Receipts.Id		
                )
            SELECT
                Receipts.Id,
            	Receipts.ShopName,
            	Receipts.DateTime,
            	Coasts.Value AS Coast
            FROM Receipts
            JOIN Coasts
              ON Receipts.Id = Coasts.ReceiptId
        """;

        var receipts = await _queryExecutor.Query<ReceiptDto>(sqlQuery, paramters);
        return receipts;
    }
}