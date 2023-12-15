namespace Mc2.CrudTest.Shared.Abstraction.Command
{
    public interface ICommandDistpatcher
    {
        Task Dispatch<TCommand>(TCommand command) where TCommand : class, ICommand; 
    }
}
