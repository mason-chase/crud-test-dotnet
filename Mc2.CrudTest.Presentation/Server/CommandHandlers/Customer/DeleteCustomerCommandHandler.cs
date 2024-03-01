using Mc2.CrudTest.Presentation.Shared;
using Mc2.CrudTest.Presentation.Shared.Commands;
using Mc2.CrudTest.Presentation.Shared.Domain;
using Mc2.CrudTest.Presentation.Shared.Interfaces.Data;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.CommandHandlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Result>
    {
        private readonly ICommandRepository _commandRepository;

        public DeleteCustomerCommandHandler(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = new Result();
            _commandRepository.DeleteAsync<Customer>(request.id);

            await _commandRepository.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
