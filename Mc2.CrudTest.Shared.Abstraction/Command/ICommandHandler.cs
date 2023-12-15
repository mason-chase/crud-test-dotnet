namespace Mc2.CrudTest.Shared.Abstraction.Command
{
    public interface ICommandHandler<in  TCommand> where TCommand:class, ICommand
    {
        Task Handle(TCommand command);
    }
}
