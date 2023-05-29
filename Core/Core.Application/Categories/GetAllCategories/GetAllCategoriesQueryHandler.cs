using Core.Application.Categories.Common;
using Core.Application.Common;

namespace Core.Application.Categories.Common;

public sealed class GetAllCategoriesQueryHandler
    : IQueryHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
{

    private readonly ISqlQueryExecutor _queryExecutor;

    public GetAllCategoriesQueryHandler(ISqlQueryExecutor queryExecutor) 
        => _queryExecutor = queryExecutor ?? throw new ArgumentNullException(nameof(queryExecutor));

    public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery query)
    {
        var sqlQuery = """
            SELECT
                Categories.Id,
                Categories.Name,
                Categories.ParentCategoryId,
                ParentCategories.Name AS ParentCategoryName

            FROM Categories

            JOIN Categories AS ParentCategories ON 
                Categories.ParentId = ParentCategories.Id AND 
                Categories.UserId = ParentCategories.UserId

            WHERE Categories.UserId = @UserId
        """;

        return await _queryExecutor.Query<CategoryDto>(query: sqlQuery, parameters: query);
    }
}