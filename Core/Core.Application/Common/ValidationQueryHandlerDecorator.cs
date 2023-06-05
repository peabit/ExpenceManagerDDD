namespace Core.Application.Common;

public sealed class ValidationQueryHandlerDecorator<TQuery, TResult>
    : IQueryHandler<TQuery, TResult>
{
    private readonly IQueryHandler<TQuery, TResult> _decorated;
    private readonly IRequestValidator<TQuery> _validator;

    public ValidationQueryHandlerDecorator(IQueryHandler<TQuery, TResult> decorated, IRequestValidator<TQuery> validator)
    {
        _decorated = decorated;
        _validator = validator;
    }

    public Task<TResult> HandleAsync(TQuery query)
    {
        _validator.ThrowExceptionIfInvalid(query);
        return _decorated.HandleAsync(query);
    }
}