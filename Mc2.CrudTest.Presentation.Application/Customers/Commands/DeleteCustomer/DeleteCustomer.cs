using Mc2.CrudTest.Presentation.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Application.Common.Models;
using Mc2.CrudTest.Presentation.Domain.Entities;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Customers.Commands.DeleteCustomer
{
    public record DeleteCustomerCommand(int id) : IRequest<Result>;

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
