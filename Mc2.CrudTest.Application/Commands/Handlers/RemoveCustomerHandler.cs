using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Shared.Abstraction.Command;

namespace Mc2.CrudTest.Application.Commands.Handlers
{
    internal sealed class RemoveCustomerHandler: ICommandHandler<RemoveCustomer>
    {
        private readonly ICustomerRepository _repository;
        public RemoveCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCustomer command)
        {
            var customer = await _repository.Take(command.Id);
            if(customer is null)
            {
                throw new NotFoundCustomer(command.Id);
            }
            await _repository.Remove(customer);
        }
    }
}
