using Core.Application.Common;

namespace Core.Application.Reports.FindTotalByCategories;

public sealed class FindTotalsByCategoriesQueryHandler 
    : IQueryHandler<FindTotalsByCategoriesQuery, TotalsByCategoriesDto>
{
    private readonly ISqlQueryExecutor _sqlQueryExecutor;

    public FindTotalsByCategoriesQueryHandler(ISqlQueryExecutor sqlQueryExecutor) 
        => _sqlQueryExecutor = sqlQueryExecutor ?? throw new ArgumentNullException(nameof(sqlQueryExecutor));

    public async Task<TotalsByCategoriesDto> Query(FindTotalsByCategoriesQuery query)
    {
        var sqlQuery = """
            WITH 
                RECURSIVE ChildCategories AS (
                    SELECT 
        			    Categories.ParentId AS ParentId,
        			    Categories.Id       AS ChildId

        		    FROM Categories
        		    WHERE Categories.ParentId IN @CategoryIds

        		    UNION ALL

        		    SELECT 
        			    ChildCategories.ParentId,
        			    Categories.Id AS ChildId

        		    FROM ChildCategories
        		    JOIN Categories
                        ON Categories.ParentId = ChildCategories.ChildId
        	    ),
        	    CategoryBranches AS (
        		    SELECT 
        			    ChildCategories.ParentId AS StartCategoryId,
        			    ChildCategories.ChildId  AS CategoryId	
        		    
                    FROM ChildCategories

        		    UNION ALL

        		    SELECT
        			    Categories.Id AS StartCategoryId,
        			    Categories.Id AS CategoryId
        		    FROM Categories
        		    WHERE Categories.Id IN @CategoryIds
        	    )
            SELECT 
        	    Categories.Name AS Category,
        	    SUM( ReceiptItems.Quantity * ReceiptItems.Price ) AS Total

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
        """;

        var totals = await _sqlQueryExecutor.Query<TotalByCategoryDto>(sqlQuery, query);
        return new TotalsByCategoriesDto(query.From, query.To, totals);
    }
}