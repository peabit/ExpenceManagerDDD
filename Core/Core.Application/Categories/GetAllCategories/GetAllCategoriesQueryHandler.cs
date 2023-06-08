using Core.Domain.Exceptions;
using Core.Application.Common;

namespace Core.Application.Categories.Common;

public sealed class GetAllCategoriesQueryHandler
    : IQueryHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
{

    private readonly ISqlQueryExecutor _queryExecutor;

    public GetAllCategoriesQueryHandler(ISqlQueryExecutor queryExecutor) 
        => _queryExecutor = queryExecutor ?? throw new ArgumentNullException(nameof(queryExecutor));

    public async Task<IEnumerable<CategoryDto>> HandleAsync(GetAllCategoriesQuery query)
    {
        var sqlQuery = """
            SELECT
                Categories.Id,
                Categories.Name,
                Categories.ParentCategoryId,
                ParentCategories.Name AS ParentCategoryName

            FROM Categories

            LEFT JOIN Categories AS ParentCategories ON 
                Categories.ParentCategoryId = ParentCategories.Id AND 
                Categories.UserId = ParentCategories.UserId

            WHERE Categories.UserId = @UserId
        """;

        var categories = await _queryExecutor.Query<CategoryDto>(query: sqlQuery, parameters: query);

        if (!categories.Any())
        {
            throw new NotFoundException($"User with id {query.UserId} does not have categories");
        }

        return categories;
    }
}