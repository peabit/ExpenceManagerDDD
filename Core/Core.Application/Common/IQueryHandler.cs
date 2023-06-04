namespace Core.Application.Common;

public interface IQueryHandler<TQuery, TResult>
{
    Task<TResult> HandleAsync(TQuery query);
}