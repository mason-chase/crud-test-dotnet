using Mc2.CrudTest.Contracts;

namespace Mc2.CrudTest.Application.Handlers;

public class CommandHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult>
{
    private readonly ICommand<TRequest, TResult> _command;

    public CommandHandler(ICommand<TRequest, TResult> command) => _command = command;

    public async Task<TResult> Handle(TRequest request)
    {
        return await _command.Execute(request);
    }
}
