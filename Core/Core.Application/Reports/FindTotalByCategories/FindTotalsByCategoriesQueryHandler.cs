using Core.Application.Common;

namespace Core.Application.Reports.FindTotalByCategories;

public sealed class FindTotalsByCategoriesQueryHandler
{
    private readonly ISqlQueryExecutor _sqlQueryExecutor;

    public FindTotalsByCategoriesQueryHandler(ISqlQueryExecutor sqlQueryExecutor) 
        => _sqlQueryExecutor = sqlQueryExecutor ?? throw new ArgumentNullException(nameof(sqlQueryExecutor));

    public async Task<IEnumerable<TotalByCategoryDto>> Query(FindTotalsByCategoriesQuery query)
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
        		      ON ChildCategories.ChildId = Categories.ParentId
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

            JOIN CategoryBranches
              ON ReceiptItems.CategoryId = CategoryBranches.CategoryId

            JOIN Categories
              ON Categories.Id = CategoryBranches.StartCategoryId

            GROUP BY Category
        """;

        return await _sqlQueryExecutor.Query<TotalByCategoryDto>(sqlQuery, query);
    }
}