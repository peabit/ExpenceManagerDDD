using Core.Application.Common;

namespace Core.Infrastructure.Application;

public sealed class UnitOfWorkCommandHandlerDecorator<TCommand> 
    : ICommandHandler<TCommand>
    where TCommand : class
{
    private readonly ICommandHandler<TCommand> _decorated;
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkCommandHandlerDecorator(ICommandHandler<TCommand> decorated, IUnitOfWork unitOfWork)
    {
        _decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task HandleAsync(TCommand command)
    {
        await _decorated.HandleAsync(command);
        await _unitOfWork.CommitAsync();
    }
}