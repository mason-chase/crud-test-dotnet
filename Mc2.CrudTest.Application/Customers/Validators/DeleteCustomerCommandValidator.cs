using FluentValidation;
using Mc2.CrudTest.Application.Contract.Customers.Commands;

namespace Mc2.CrudTest.Application.Customers.Validators;

internal class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();
    }
}
