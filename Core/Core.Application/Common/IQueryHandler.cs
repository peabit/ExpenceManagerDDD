namespace Core.Application.Common;

public interface IQueryHandler<TQuery, TResult>
{
    Task<TResult> Query(TQuery query);
}