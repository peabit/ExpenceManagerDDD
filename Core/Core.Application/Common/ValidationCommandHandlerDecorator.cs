namespace Core.Application.Common;

public sealed class ValidationCommandHandlerDecorator<TCommand>
    : ICommandHandler<TCommand>
    where TCommand : class
{
    private readonly ICommandHandler<TCommand> _decorated;
    private readonly IRequestValidator<TCommand> _validator;

    public ValidationCommandHandlerDecorator(ICommandHandler<TCommand> decorated, IRequestValidator<TCommand> validator)
    {
        _decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public Task HandleAsync(TCommand command)
    {
        _validator.ThrowExceptionIfInvalid(command);
        return _decorated.HandleAsync(command);
    }
}