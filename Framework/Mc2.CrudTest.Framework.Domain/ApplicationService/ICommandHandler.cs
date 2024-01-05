namespace Mc2.CrudTest.Framework.Domain.ApplicationService
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}
