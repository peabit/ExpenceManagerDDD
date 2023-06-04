namespace Core.Application.Common;

public sealed class ValidationQueryHandlerDecorator<TQuery, TResult>
    : IQueryHandler<TQuery, TResult>
{
    private readonly IQueryHandler<TQuery, TResult> _decorated;

    public ValidationQueryHandlerDecorator(IQueryHandler<TQuery, TResult> decorated)
    {
        _decorated = decorated;
    }

    public Task<TResult> HandleAsync(TQuery query)
    {
        _ = 1;
        return _decorated.HandleAsync(query);
    }
}