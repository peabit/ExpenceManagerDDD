namespace Core.Application.Common;

public sealed class ValidationQueryHandlerDecorator<TQuery, TResult> 
    : IQueryHandler<TQuery, TResult>
    where TQuery : class
{
    private readonly IQueryHandler<TQuery, TResult> _decorated;
    private readonly IRequestValidator<TQuery> _validator;

    public ValidationQueryHandlerDecorator(IQueryHandler<TQuery, TResult> decorated, IRequestValidator<TQuery> validator)
    {
        _decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public Task<TResult> HandleAsync(TQuery query)
    {
        _validator.ThrowExceptionIfInvalid(query);
        return _decorated.HandleAsync(query);
    }
}