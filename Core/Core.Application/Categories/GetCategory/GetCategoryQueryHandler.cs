using Core.Application.Categories.Common;
using Core.Application.Common;

namespace Core.Application.Categories.GetCategory;

public sealed class GetCategoryQueryHandler
    : IQueryHandler<GetCategoryQuery, CategoryDto>
{
    private readonly ISqlQueryExecutor _queryExecutor;

    public GetCategoryQueryHandler(ISqlQueryExecutor queryExecutor) 
        => _queryExecutor = queryExecutor ?? throw new ArgumentNullException(nameof(queryExecutor));

    public async Task<CategoryDto> HandleAsync(GetCategoryQuery query)
    {
        var sqlQuery = """
            SELECT
                Categories.Id,
                Categories.Name,
                Categories.ParentId,
                ParentCategories.Name AS ParentName
        
            FROM Categories
        
            LEFT JOIN Categories AS ParentCategories ON 
                Categories.ParentId = ParentCategories.Id AND 
                Categories.UserId = ParentCategories.UserId
        
            WHERE 
                Categories.UserId = @UserId AND
                Categories.Id = @CategoryId
        """;

        return await _queryExecutor.QueryFirstOrDefault<CategoryDto>(query: sqlQuery, parameters: query);
    }
}