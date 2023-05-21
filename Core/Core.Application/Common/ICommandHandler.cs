namespace Core.Application.Common;

public interface ICommandHandler<in TCommand>
    where TCommand : class
{
    Task Handle(TCommand command);
}