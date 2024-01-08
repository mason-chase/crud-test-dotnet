namespace Mc2.Framework.Application;

public interface ICommandHandler<in TCommand> where TCommand: ICommand
{
  Task Handle(TCommand command);
}