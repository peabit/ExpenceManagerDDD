namespace Core.Application.Common;

public interface ISqlQueryExecutor
{
    Task<IEnumerable<TResult>> Query<TResult>(string query, object parameters);
    Task<TResult> QueryFirstOrDefault<TResult>(string query, object parameters);
}