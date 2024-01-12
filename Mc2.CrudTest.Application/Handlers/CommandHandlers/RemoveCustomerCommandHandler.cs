using System.ComponentModel.DataAnnotations;
using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Common.Helpers;
using Mc2.CrudTest.Application.Common.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.CommandHandlers;

public class RemoveCustomerCommandHandler : IRequestHandler<RemoveCustomerCommand, bool>
{
    private readonly ICustomersRepository _repository;

    public RemoveCustomerCommandHandler(ICustomersRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
    {
        return await _repository.RemoveCustomerAsync(request.Id);
    }
}