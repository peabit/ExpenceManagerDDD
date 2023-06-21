using Core.Application.Common;

namespace Core.Application.Reports.FindTotalsByCategories;

public sealed class FindTotalsByCategoriesQueryHandler 
    : IQueryHandler<FindTotalsByCategoriesQuery, TotalsByCategoriesDto>
{
    private readonly ISqlQueryExecutor _sqlQueryExecutor;
    
    private const string _totalByPeriodSqlQuery = """
        SELECT SUM( ReceiptItems.Quantity * ReceiptItems.Price ) AS Value
        FROM ReceiptItems   
        JOIN Receipts
            ON Receipts.Id = ReceiptItems.ReceiptId
        WHERE Receipts.DateTime BETWEEN @From AND @To
          AND Receipts.UserId = @UserId
    """;

    public FindTotalsByCategoriesQueryHandler(ISqlQueryExecutor sqlQueryExecutor) 
        => _sqlQueryExecutor = sqlQueryExecutor ?? throw new ArgumentNullException(nameof(sqlQueryExecutor));

    public async Task<TotalsByCategoriesDto> HandleAsync(FindTotalsByCategoriesQuery query)
    {
        var sqlQuery = $"""
            WITH 
                RECURSIVE ChildCategories AS (
                    SELECT 
                        Categories.ParentCategoryId,
                        Categories.Id AS ChildCategoryId

                    FROM Categories
                    WHERE Categories.ParentCategoryId IN @CategoryIds
                      AND Categories.UserId = @UserId

                    UNION ALL

                    SELECT 
                        ChildCategories.ParentCategoryId,
                        Categories.Id AS ChildCategoryId

                    FROM ChildCategories
                    JOIN Categories
                        ON Categories.ParentCategoryId = ChildCategories.ChildCategoryId
                    WHERE Categories.UserId = @UserId
                ),
                CategoryBranches AS (
                    SELECT 
                        ChildCategories.ParentCategoryId AS StartCategoryId,
                        ChildCategories.ChildCategoryId  AS CategoryId  

                    FROM ChildCategories

                    UNION ALL

                    SELECT
                        Categories.Id AS StartCategoryId,
                        Categories.Id AS CategoryId
                    FROM Categories
                    WHERE Categories.Id IN @CategoryIds
                ),
                TotalByCategory AS (
                    SELECT 
                        Categories.Name AS Category,
                        SUM( ReceiptItems.Quantity * ReceiptItems.Price ) AS Value
        
                    FROM ReceiptItems
        
                    JOIN Receipts
                        ON Receipts.Id = ReceiptItems.ReceiptId
        
                    JOIN CategoryBranches
                        ON CategoryBranches.CategoryId = ReceiptItems.CategoryId
        
                    JOIN Categories
                        ON Categories.Id = CategoryBranches.StartCategoryId
        
                    WHERE Receipts.DateTime BETWEEN @From AND @To
                      AND Receipts.UserId = @UserId
        
                    GROUP BY Category         
                ),
                TotalByPeriod AS ( {_totalByPeriodSqlQuery} )
                SELECT
                    TotalByCategory.Category,
                    TotalByCategory.Value AS Total,
                    ROUND((TotalByCategory.Value / (SELECT Value FROM TotalByPeriod) * 100), 2) AS SharePercent
                FROM TotalByCategory

        """;

        var totals = await _sqlQueryExecutor.Query<TotalByCategoryDto>(sqlQuery, query);

        var totalByPeriod = await GetTotalByPeriod(query.From, query.To, query.UserId);

        return new TotalsByCategoriesDto(query.From, query.To, totals, totalByPeriod);
    }

    private async Task<decimal> GetTotalByPeriod(DateTime from, DateTime to, string userId)
        => await _sqlQueryExecutor.ExecuteScalarAsync<decimal>(_totalByPeriodSqlQuery, new { From = from, To = to, UserId = userId });
}